using Domain.ValueObjects.ValueObject;
using Shared.Types.Exceptions.Validation;

namespace Domain.ValueObjects.Products
{
    public sealed record ProductDiscountPercent : ValueObject<ProductDiscountPercent, short>, IValueObject<ProductDiscountPercent, short>
    {
        internal ProductDiscountPercent(short value) : base(value) { }

        public static ProductDiscountPercent FromValue(short value)
        {
            var name = nameof(ProductDiscountPercent);

            ValueNullException.ThrowIfNull(value, name);
            ValueOutOfRangeException.ThrowIfOutsideRange(value, name, 100, 1);

            return new(value);
        }
    }
}
