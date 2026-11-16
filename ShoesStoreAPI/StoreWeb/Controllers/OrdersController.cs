using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreData.Services;

namespace StoreWeb.Controllers
{
    [Authorize]
    public sealed class OrdersController(OrderService orders) : Controller
    {
        /// <summary>Показывает свои или все заказы.</summary>
        [HttpGet("/orders")]
        public async Task<IActionResult> IndexAsync(CancellationToken ct)
        {
            var staff = User.IsInRole("Администратор") || User.IsInRole("Менеджер");
            var login = User.FindFirstValue("login");
            if (!staff && login is null)
                return Forbid();

            return View("Index", await orders.ListAsync(staff ? null : login, ct));
        }

        /// <summary>Создаёт заказ для клиента.</summary>
        [HttpPost("/orders"), Authorize(Roles = "Клиент"), ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAsync(long productId, CancellationToken ct)
        {
            if (!long.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out var userId))
                return Forbid();

            try
            {
                var orderId = await orders.CreateAsync(userId, productId, ct);
                return orderId is null ? NotFound() : Redirect("/orders");
            }
            catch (InvalidOperationException error)
            {
                TempData["OrderError"] = error.Message;
            }
            catch (DbUpdateException)
            {
                TempData["OrderError"] = "Не удалось создать заказ. Попробуйте ещё раз.";
            }

            return Redirect("/");
        }
    }
}
