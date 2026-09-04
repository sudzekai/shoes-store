using Domain.ValueObjects.ValueObject;
using Shared.Types.Exceptions.Validation;

namespace Domain.ValueObjects.Manufacturers
{
    public sealed record ManufacturerName : ValueObject<ManufacturerName, string>, IValueObject<ManufacturerName, string>
    {
        internal ManufacturerName(string value) : base(value) { }

        public static ManufacturerName FromValue(string value)
        {
            var name = nameof(ManufacturerName);

            ValueNullException.ThrowIfNullOrWhiteSpace(value, name);
            ValueLengthOutOfRangeException.ThrowIfGreaterThan(value, name, 50);

            return new(value);
        }
    }
}
