using Domain.ValueObjects.Roles;
using Domain.ValueObjects.Users;

namespace Domain.Objects.Users
{
    /// <summary>Частичная реализация пользователя: свойства и операции изменения.</summary>
    public sealed partial class User
    {
        /// <summary>Идентификатор пользователя.</summary>
        public UserId Id { get; private set; }

        /// <summary>Идентификатор роли пользователя.</summary>
        public RoleId RoleId { get; private set; }

        /// <summary>ФИО пользователя.</summary>
        public UserFullName FullName { get; private set; }

        /// <summary>Логин (email) пользователя.</summary>
        public UserLogin Login { get; private set; }

        /// <summary>Хеш пароля пользователя.</summary>
        public UserPasswordHash PasswordHash { get; private set; }

        /// <summary>Изменить роль пользователя.</summary>
        public void ChangeRoleId(RoleId roleId)
            => RoleId = roleId;

        /// <summary>Изменить ФИО пользователя.</summary>
        public void ChangeFullName(UserFullName fullName)
            => FullName = fullName;

        /// <summary>Изменить логин пользователя.</summary>
        public void ChangeLogin(UserLogin login)
            => Login = login;

        /// <summary>Изменить хеш пароля пользователя.</summary>
        public void ChangePasswordHash(UserPasswordHash passwordHash)
            => PasswordHash = passwordHash;
    }
}