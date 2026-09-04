using Domain.ValueObjects.ValueObject;
using Shared.Types.Exceptions.Validation;

namespace Domain.ValueObjects.Products
{
    /// <summary>ValueObject для описания товара.</summary>
    public sealed record ProductDescription : ValueObject<ProductDescription, string>, IValueObject<ProductDescription, string>
    {
        internal ProductDescription(string value) : base(value) { }

        /// <summary>Создаёт ProductDescription (если null — превращает в пустую строку, проверяет длину ≤ 255).</summary>
        public static ProductDescription FromValue(string value)
        {
            var name = nameof(ProductDescription);

            value ??= "";

            ValueLengthOutOfRangeException.ThrowIfGreaterThan(value, name, 255);

            return new(value);
        }
    }
}