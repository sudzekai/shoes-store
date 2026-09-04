using Domain.ValueObjects.ValueObject;
using Shared.Types.Exceptions.Validation;

namespace Domain.ValueObjects.Products
{
    /// <summary>ValueObject для названия товара.</summary>
    public sealed record ProductName : ValueObject<ProductName, string>, IValueObject<ProductName, string>
    {
        internal ProductName(string value) : base(value) { }

        /// <summary>Создаёт ProductName с валидацией (не пустое, длина ≤ 50).</summary>
        public static ProductName FromValue(string value)
        {
            var name = nameof(ProductName);

            ValueNullException.ThrowIfNullOrWhiteSpace(value, name);
            ValueLengthOutOfRangeException.ThrowIfGreaterThan(value, name, 50);

            return new(value);
        }
    }
}