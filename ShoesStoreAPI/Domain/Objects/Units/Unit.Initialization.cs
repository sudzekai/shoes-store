using Domain.ValueObjects.Units;

namespace Domain.Objects.Units
{
    public sealed partial class Unit
    {
        private Unit(UnitName name)
        {
            Id = new(0);
            Name = name;
        }

        private Unit(long id, string name)
        {
            Id = new(id);
            Name = new(name);
        }

        public static Unit Create(UnitName name)
            => new(name);

        internal static Unit Restore(long id, string name)
            => new(id, name);
    }
}
