using Microsoft.AspNetCore.Mvc;
using Presentation.Services;
using StoreData.Dto;
using StoreData.Services;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public sealed class AuthController(AccountService accounts, TokenService tokens) : ControllerBase
    {
        /// <summary>Проверяет пароль и выдаёт ключ для входа.</summary>
        [HttpPost("login")]
        public async Task<ActionResult<LoginResult>> LoginAsync(LoginDto input, CancellationToken ct)
        {
            var account = await accounts.SignInAsync(input, ct);
            return account is null ? Unauthorized() : Ok(tokens.Issue(account));
        }
    }
}
