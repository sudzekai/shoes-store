using Domain.ValueObjects.ValueObject;
using Shared.Types.Exceptions.Validation;

namespace Domain.ValueObjects.Suppliers
{
    public sealed record SupplierName : ValueObject<SupplierName, string>, IValueObject<SupplierName, string>
    {
        internal SupplierName(string value) : base(value) { }

        public static SupplierName FromValue(string value)
        {
            var name = nameof(SupplierName);

            ValueNullException.ThrowIfNullOrWhiteSpace(value, name);
            ValueLengthOutOfRangeException.ThrowIfGreaterThan(value, name, 50);

            return new(value);
        }
    }
}
