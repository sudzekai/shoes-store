using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StoreData.Dto;
using StoreData.Services;

namespace Presentation.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/orders")]
    public sealed class OrdersController(OrderService orders) : ControllerBase
    {
        /// <summary>Показывает заказы с учётом прав.</summary>
        [HttpGet]
        public async Task<ActionResult<List<OrderDto>>> ListAsync([FromQuery] string? login, CancellationToken ct)
        {
            if (User.IsInRole("Администратор") || User.IsInRole("Менеджер"))
                return Ok(await orders.ListAsync(login, ct));

            var ownLogin = User.FindFirst("login")?.Value;
            if (ownLogin is null || (login is not null && !string.Equals(login, ownLogin, StringComparison.OrdinalIgnoreCase)))
                return Forbid();

            return Ok(await orders.ListAsync(ownLogin, ct));
        }

        /// <summary>Показывает доступные статусы.</summary>
        [Authorize(Roles = "Администратор,Менеджер")]
        [HttpGet("statuses")]
        public Task<List<LookupDto>> StatusesAsync(CancellationToken ct) => orders.GetStatusesAsync(ct);

        /// <summary>Меняет статус и дату доставки.</summary>
        [Authorize(Roles = "Администратор,Менеджер")]
        [HttpPatch("{id:long}")]
        public async Task<IActionResult> UpdateAsync(long id, OrderEditDto input, CancellationToken ct)
        {
            try
            {
                return await orders.UpdateAsync(id, input, ct) ? NoContent() : NotFound();
            }
            catch (ValidationException error)
            {
                return BadRequest(error.Message);
            }
        }
    }
}
