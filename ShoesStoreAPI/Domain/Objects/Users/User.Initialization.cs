using Domain.ValueObjects.Roles;
using Domain.ValueObjects.Users;

namespace Domain.Objects.Users
{
    /// <summary>Частичная реализация сущности пользователя: создание и восстановление.</summary>
    public sealed partial class User
    {
        /// <summary>Конструктор для создания нового пользователя (id = 0).</summary>
        private User(RoleId roleId, UserFullName fullName, UserLogin login, UserPasswordHash passwordHash)
        {
            Id = new(0);
            RoleId = roleId;
            FullName = fullName;
            Login = login;
            PasswordHash = passwordHash;
        }

        /// <summary>Восстановить пользователя из хранилища (с указанными значениями).</summary>
        private User(long id, long roleId, string fullName, string login, string passwordHash)
        {
            Id = new(id);
            RoleId = new(roleId);
            FullName = new(fullName);
            Login = new(login);
            PasswordHash = new(passwordHash);
        }

        /// <summary>Создать нового пользователя.</summary>
        public static User Create(RoleId roleId, UserFullName fullName, UserLogin login, UserPasswordHash passwordHash)
            => new(roleId, fullName, login, passwordHash);

        /// <summary>Восстановить пользователя из хранилища.</summary>
        internal static User Restore(long id, long roleId, string fullName, string login, string passwordHash)
            => new(id, roleId, fullName, login, passwordHash);
    }
}