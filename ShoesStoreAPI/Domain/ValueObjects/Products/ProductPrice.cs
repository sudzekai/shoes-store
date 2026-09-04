using Domain.ValueObjects.ValueObject;
using Shared.Types.Exceptions.Validation;

namespace Domain.ValueObjects.Products
{
    /// <summary>ValueObject для цены товара.</summary>
    public sealed record ProductPrice : ValueObject<ProductPrice, decimal>, IValueObject<ProductPrice, decimal>
    {
        internal ProductPrice(decimal value) : base(value) { }

        /// <summary>Создаёт ProductPrice (value >= 1).</summary>
        public static ProductPrice FromValue(decimal value)
        {
            ValueOutOfRangeException.ThrowIfLess(value, nameof(ProductPrice), 1);

            return new(value);
        }
    }
}