using Microsoft.EntityFrameworkCore;
using StoreData.Data;
using StoreData.Dto;

namespace StoreData.Services
{
    public sealed class AccountService(ShoesStoreContext db)
    {
        /// <summary>Проверяет логин и пароль.</summary>
        public async Task<AccountDto?> SignInAsync(LoginDto input, CancellationToken ct = default)
        {
            var user = await db.Users.AsNoTracking().Where(user => user.Login == input.Login)
                .Select(user => new { user.Id, user.Login, user.FullName, user.Password, Role = user.Role.Name })
                .SingleOrDefaultAsync(ct);

            if (user is null || !string.Equals(user.Password, input.Password, StringComparison.Ordinal))
                return null;

            return new(user.Id, user.Login, user.FullName, user.Role);
        }
    }
}
