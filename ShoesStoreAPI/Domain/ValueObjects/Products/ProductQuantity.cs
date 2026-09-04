using Domain.ValueObjects.ValueObject;
using Shared.Types.Exceptions.Validation;

namespace Domain.ValueObjects.Products
{
    /// <summary>ValueObject для количества товара.</summary>
    public sealed record ProductQuantity : ValueObject<ProductQuantity, short>, IValueObject<ProductQuantity, short>
    {
        internal ProductQuantity(short value) : base(value) { }

        /// <summary>Создаёт ProductQuantity (value >= 0).</summary>
        public static ProductQuantity FromValue(short value)
        {
            ValueOutOfRangeException.ThrowIfLess(value, nameof(ProductQuantity), 0);

            return new(value);
        }
    }
}