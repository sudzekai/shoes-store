using Domain.ValueObjects.Roles;

namespace Domain.Objects.Roles
{
    public sealed partial class Role
    {
        private Role(RoleName name)
        {
            Id = new(0);
            Name = name;
        }

        private Role(long id, string name)
        {
            Id = new(id);
            Name = new(name);
        }

        public static Role Create(RoleName name)
            => new(name);

        internal static Role Restore(long id, string name)
            => new(id, name);
    }
}
