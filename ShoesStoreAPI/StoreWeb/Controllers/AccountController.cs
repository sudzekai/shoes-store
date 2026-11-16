using System.Globalization;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using StoreData.Dto;
using StoreData.Services;

namespace StoreWeb.Controllers
{
    public sealed class AccountController(AccountService accounts) : Controller
    {
        /// <summary>Открывает страницу входа.</summary>
        [HttpGet("/account/login")]
        public IActionResult Login() => View();

        /// <summary>Входит по логину и паролю.</summary>
        [HttpPost("/account/login"), ValidateAntiForgeryToken]
        public async Task<IActionResult> LoginAsync(LoginDto input, CancellationToken ct)
        {
            var account = ModelState.IsValid ? await accounts.SignInAsync(input, ct) : null;
            if (account is null)
            {
                ModelState.AddModelError("", "Проверьте логин и пароль.");
                return View("Login");
            }

            var identity = new ClaimsIdentity(
                [
                    new Claim(ClaimTypes.NameIdentifier, account.Id.ToString(CultureInfo.InvariantCulture)),
                    new Claim(ClaimTypes.Name, account.FullName),
                    new Claim(ClaimTypes.Role, account.Role),
                    new Claim("login", account.Login)
                ],
                CookieAuthenticationDefaults.AuthenticationScheme);

            await HttpContext.SignInAsync(new ClaimsPrincipal(identity));
            return Redirect("/");
        }

        /// <summary>Завершает вход.</summary>
        [HttpPost("/account/logout"), ValidateAntiForgeryToken]
        public async Task<IActionResult> LogoutAsync()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }
    }
}
