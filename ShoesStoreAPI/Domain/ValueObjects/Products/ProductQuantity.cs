using Domain.ValueObjects.ValueObject;
using Shared.Types.Exceptions.Validation;

namespace Domain.ValueObjects.Products
{
    public sealed record ProductQuantity : ValueObject<ProductQuantity, short>, IValueObject<ProductQuantity, short>
    {
        internal ProductQuantity(short value) : base(value) { }

        public static ProductQuantity FromValue(short value)
        {
            ValueOutOfRangeException.ThrowIfLess(value, nameof(ProductQuantity), 0);
            
            return new(value);
        }
    }
}
