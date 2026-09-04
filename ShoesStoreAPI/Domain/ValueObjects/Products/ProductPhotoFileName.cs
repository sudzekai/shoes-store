using Domain.ValueObjects.ValueObject;
using Shared.Types.Exceptions.Validation;

namespace Domain.ValueObjects.Products
{
    /// <summary>ValueObject для имени файла фотографии товара (nullable).</summary>
    public sealed record ProductPhotoFileName : NullableValueObject<ProductPhotoFileName, string>, INullableValueObject<ProductPhotoFileName, string>
    {
        internal ProductPhotoFileName(string? value) : base(value) { }

        /// <summary>Создаёт ProductPhotoFileName; null допускается, иначе выполняется проверка.</summary>
        public static ProductPhotoFileName FromValue(string? value)
        {
            if (value is null)
                return new((string?)null);

            var name = nameof(ProductPhotoFileName);

            ValueNullException.ThrowIfNullOrWhiteSpace(value, name);

            return new(value);
        }
    }
}