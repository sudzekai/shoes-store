using Domain.ValueObjects.ValueObject;
using Shared.Types.Exceptions.Validation;

namespace Domain.ValueObjects.Products
{
    /// <summary>ValueObject для артикула товара.</summary>
    public sealed record ProductArticle : ValueObject<ProductArticle, string>, IValueObject<ProductArticle, string>
    {
        internal ProductArticle(string value) : base(value) { }

        /// <summary>Создаёт ProductArticle с валидацией (не пустой, длина = 6).</summary>
        public static ProductArticle FromValue(string value)
        {
            var name = nameof(ProductArticle);

            ValueNullException.ThrowIfNullOrWhiteSpace(value, name);
            ValueLengthOutOfRangeException.ThrowIfNotEqual(value, name, 6);

            return new(value);
        }
    }
}