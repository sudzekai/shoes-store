using Domain.ValueObjects.ValueObject;
using Shared.Types.Exceptions.Validation;

namespace Domain.ValueObjects.Manufacturers
{
    public sealed record ManufacturerId : ValueObject<ManufacturerId, long>, IValueObject<ManufacturerId, long>
    {
        internal ManufacturerId(long value) : base(value) { }

        public static ManufacturerId FromValue(long value)
        {
            ValueOutOfRangeException.ThrowIfLess(value, nameof(ManufacturerId), 1);

            return new(value);
        }
    }
}
