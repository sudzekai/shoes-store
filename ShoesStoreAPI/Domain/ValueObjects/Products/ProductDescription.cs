using Domain.ValueObjects.ValueObject;
using Shared.Types.Exceptions.Validation;

namespace Domain.ValueObjects.Products
{
    public sealed record ProductDescription : ValueObject<ProductDescription, string>, IValueObject<ProductDescription, string>
    {
        internal ProductDescription(string value) : base(value) { }

        public static ProductDescription FromValue(string value)
        {
            var name = nameof(ProductDescription);

            value ??= "";

            ValueLengthOutOfRangeException.ThrowIfGreaterThan(value, name, 255);

            return new(value);
        }
    }
}
