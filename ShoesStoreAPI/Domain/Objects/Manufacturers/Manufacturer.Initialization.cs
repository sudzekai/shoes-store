using Domain.ValueObjects.Manufacturers;

namespace Domain.Objects.Manufacturers
{
    public sealed partial class Manufacturer
    {
        private Manufacturer(ManufacturerName name)
        {
            Id = new(0);
            Name = name;
        }

        private Manufacturer(long id, string name)
        {
            Id = new(id);
            Name = new(name);
        }

        public static Manufacturer Create(ManufacturerName name)
            => new(name);

        internal static Manufacturer Restore(long id, string name)
            => new(id, name);
    }
}
