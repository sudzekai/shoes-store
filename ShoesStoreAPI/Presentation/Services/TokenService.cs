using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using StoreData.Dto;

namespace Presentation.Services
{
    public sealed record JwtSettings(SymmetricSecurityKey Key)
    {
        public string Issuer => "ShoesStore";
        public string Audience => "ShoesStoreClients";
    }

    public sealed record LoginResult(string AccessToken, AccountDto Account);

    public sealed class TokenService(JwtSettings settings, TimeProvider clock, JwtSecurityTokenHandler handler)
    {
        /// <summary>Выдаёт ключ для входа в API.</summary>
        public LoginResult Issue(AccountDto account)
        {
            var token = new JwtSecurityToken(
                settings.Issuer, settings.Audience,
                [
                    new Claim("sub", account.Id.ToString(CultureInfo.InvariantCulture)),
                    new Claim("name", account.FullName),
                    new Claim("login", account.Login),
                    new Claim("role", account.Role)
                ],
                expires: clock.GetUtcNow().AddHours(2).UtcDateTime,
                signingCredentials: new SigningCredentials(settings.Key, SecurityAlgorithms.HmacSha256));

            return new(handler.WriteToken(token), account);
        }
    }
}
