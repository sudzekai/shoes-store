using Domain.ValueObjects.ValueObject;
using Shared.Types.Exceptions.Validation;

namespace Domain.ValueObjects.Orders
{
    public sealed record OrderId : ValueObject<OrderId, long>, IValueObject<OrderId, long>
    {
        internal OrderId(long value) : base(value) { }

        public static OrderId FromValue(long value)
        {
            ValueOutOfRangeException.ThrowIfLess(value, nameof(OrderId), 0);

            return new(value);
        }
    }
}
