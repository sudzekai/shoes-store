using Domain.ValueObjects.ValueObject;
using Shared.Types.Exceptions.Validation;

namespace Domain.ValueObjects.Suppliers
{
    /// <summary>ValueObject для идентификатора поставщика.</summary>
    public sealed record SupplierId : ValueObject<SupplierId, long>, IValueObject<SupplierId, long>
    {
        internal SupplierId(long value) : base(value) { }

        /// <summary>Создаёт SupplierId (value >= 1).</summary>
        public static SupplierId FromValue(long value)
        {
            ValueOutOfRangeException.ThrowIfLess(value, nameof(SupplierId), 1);

            return new(value);
        }
    }
}