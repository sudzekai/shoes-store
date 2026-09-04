using Domain.ValueObjects.ValueObject;
using Shared.Types.Exceptions.Validation;

namespace Domain.ValueObjects.Suppliers
{
    /// <summary>ValueObject для названия поставщика.</summary>
    public sealed record SupplierName : ValueObject<SupplierName, string>, IValueObject<SupplierName, string>
    {
        internal SupplierName(string value) : base(value) { }

        /// <summary>Создаёт SupplierName (не пустое, длина ≤ 50).</summary>
        public static SupplierName FromValue(string value)
        {
            var name = nameof(SupplierName);

            ValueNullException.ThrowIfNullOrWhiteSpace(value, name);
            ValueLengthOutOfRangeException.ThrowIfGreaterThan(value, name, 50);

            return new(value);
        }
    }
}