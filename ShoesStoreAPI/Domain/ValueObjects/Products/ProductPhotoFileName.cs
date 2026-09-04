using Domain.ValueObjects.ValueObject;
using Shared.Types.Exceptions.Validation;

namespace Domain.ValueObjects.Products
{
    public sealed record ProductPhotoFileName : NullableValueObject<ProductPhotoFileName, string>, INullableValueObject<ProductPhotoFileName, string>
    {
        internal ProductPhotoFileName(string? value) : base(value) { }

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
