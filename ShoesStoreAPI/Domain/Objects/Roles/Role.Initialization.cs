using Domain.ValueObjects.Roles;

namespace Domain.Objects.Roles
{
    /// <summary>
    /// Частичная реализация сущности роли: создание и восстановление.
    /// </summary>
    public sealed partial class Role
    {
        /// <summary>Конструктор для создания новой роли (id = 0).</summary>
        private Role(RoleName name)
        {
            Id = new(0);
            Name = name;
        }

        /// <summary>Внутренний конструктор для восстановления роли из хранилища.</summary>
        private Role(long id, string name)
        {
            Id = new(id);
            Name = new(name);
        }

        /// <summary>Создаёт новую роль.</summary>
        public static Role Create(RoleName name)
            => new(name);

        /// <summary>Восстанавливает роль из хранилища.</summary>
        internal static Role Restore(long id, string name)
            => new(id, name);
    }
}