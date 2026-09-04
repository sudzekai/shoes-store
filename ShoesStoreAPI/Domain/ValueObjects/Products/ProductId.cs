using Domain.ValueObjects.ValueObject;
using Shared.Types.Exceptions.Validation;

namespace Domain.ValueObjects.Products
{
    /// <summary>ValueObject для идентификатора товара.</summary>
    public sealed record ProductId : ValueObject<ProductId, long>, IValueObject<ProductId, long>
    {
        internal ProductId(long value) : base(value) { }

        /// <summary>Создаёт ProductId (value >= 1).</summary>
        public static ProductId FromValue(long value)
        {
            ValueOutOfRangeException.ThrowIfLess(value, nameof(ProductId), 1);

            return new(value);
        }
    }
}