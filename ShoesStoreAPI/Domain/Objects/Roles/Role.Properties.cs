using Domain.ValueObjects.Roles;

namespace Domain.Objects.Roles
{
    /// <summary>Частичная реализация роли: свойства и операции изменения.</summary>
    public sealed partial class Role
    {
        /// <summary>Идентификатор роли.</summary>
        public RoleId Id { get; private set; }

        /// <summary>Название роли.</summary>
        public RoleName Name { get; private set; }

        /// <summary>Изменить название роли.</summary>
        public void ChangeName(RoleName name)
            => Name = name;
    }
}