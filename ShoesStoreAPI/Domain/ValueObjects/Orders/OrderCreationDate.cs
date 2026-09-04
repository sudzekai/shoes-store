using Domain.ValueObjects.ValueObject;
using Shared.Types.Exceptions.Validation;

namespace Domain.ValueObjects.Orders
{
    public sealed record OrderCreationDate : ValueObject<OrderCreationDate, DateTime>, IValueObject<OrderCreationDate, DateTime>
    {
        internal OrderCreationDate(DateTime value) : base(value) { }

        public static OrderCreationDate FromValue(DateTime value)
        {
            ValueNullException.ThrowIfNullOrDefault(value, nameof(OrderCreationDate));

            return new(value);
        }

        public static OrderCreationDate Default => new(DateTime.Now);
    }
}
