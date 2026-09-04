using Domain.ValueObjects.ValueObject;
using Shared.Types.Exceptions.Validation;

namespace Domain.ValueObjects.Products
{
    public sealed record ProductPrice : ValueObject<ProductPrice, decimal>, IValueObject<ProductPrice, decimal>
    {
        internal ProductPrice(decimal value) : base(value) { }

        public static ProductPrice FromValue(decimal value)
        {
            ValueOutOfRangeException.ThrowIfLess(value, nameof(ProductPrice), 1);

            return new(value);
        }
    }
}
