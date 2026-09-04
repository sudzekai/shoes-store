using Domain.ValueObjects.Manufacturers;

namespace Domain.Objects.Manufacturers
{
    public sealed partial class Manufacturer
    {
        public ManufacturerId Id { get; private set; }

        public ManufacturerName Name { get; private set; }

        public void ChangeName(ManufacturerName name)
            => Name = name;
    }
}
