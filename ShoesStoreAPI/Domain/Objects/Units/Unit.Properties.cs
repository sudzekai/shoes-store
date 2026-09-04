using Domain.ValueObjects.Units;

namespace Domain.Objects.Units
{
    public sealed partial class Unit
    {
        public UnitId Id { get; private set; }

        public UnitName Name { get; private set; }

        public void ChangeName(UnitName name)
            => Name = name;
    }
}
