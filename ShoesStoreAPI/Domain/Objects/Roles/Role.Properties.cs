using Domain.ValueObjects.Roles;

namespace Domain.Objects.Roles
{
    public sealed partial class Role
    {
        public RoleId Id { get; private set; }

        public RoleName Name { get; private set; }

        public void ChangeName(RoleName name)
            => Name = name;
    }
}
