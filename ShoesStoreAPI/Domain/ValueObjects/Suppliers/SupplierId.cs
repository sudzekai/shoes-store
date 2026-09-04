using Domain.ValueObjects.ValueObject;
using Shared.Types.Exceptions.Validation;

namespace Domain.ValueObjects.Suppliers
{
    public sealed record SupplierId : ValueObject<SupplierId, long>, IValueObject<SupplierId, long>
    {
        internal SupplierId(long value) : base(value) { }

        public static SupplierId FromValue(long value)
        {
            ValueOutOfRangeException.ThrowIfLess(value, nameof(SupplierId), 1);

            return new(value);
        }
    }
}
