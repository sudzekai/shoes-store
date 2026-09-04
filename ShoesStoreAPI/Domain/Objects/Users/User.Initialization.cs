using Domain.ValueObjects.Roles;
using Domain.ValueObjects.Users;

namespace Domain.Objects.Users
{
    public sealed partial class User
    {
        private User(RoleId roleId, UserFullName fullName, UserLogin login, UserPasswordHash passwordHash)
        {
            Id = new(0);
            RoleId = roleId;
            FullName = fullName;
            Login = login;
            PasswordHash = passwordHash;
        }

        private User(long id, long roleId, string fullName, string login, string passwordHash)
        {
            Id = new(id);
            RoleId = new(roleId);
            FullName = new(fullName);
            Login = new(login);
            PasswordHash = new(passwordHash);
        }

        public static User Create(RoleId roleId, UserFullName fullName, UserLogin login, UserPasswordHash passwordHash)
            => new(roleId, fullName, login, passwordHash);

        internal static User Restore(long id, long roleId, string fullName, string login, string passwordHash)
            => new(id, roleId, fullName, login, passwordHash);
    }
}
