using Domain.ValueObjects.ValueObject;
using Shared.Types.Exceptions.Validation;

namespace Domain.ValueObjects.Orders
{
    public sealed record OrderDeliveryDate : ValueObject<OrderDeliveryDate, DateTime>, IValueObject<OrderDeliveryDate, DateTime>
    {
        internal OrderDeliveryDate(DateTime value) : base(value) { }

        public static OrderDeliveryDate FromValue(DateTime value)
        {
            ValueNullException.ThrowIfNullOrDefault(value, nameof(OrderDeliveryDate));

            return new(value);
        }

        public static OrderDeliveryDate Default => new(DateTime.Now.AddDays(7));
    }
}
