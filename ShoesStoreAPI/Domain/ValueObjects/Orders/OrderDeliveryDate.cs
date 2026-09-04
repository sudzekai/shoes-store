using Domain.ValueObjects.ValueObject;
using Shared.Types.Exceptions.Validation;

namespace Domain.ValueObjects.Orders
{
    /// <summary>ValueObject для даты доставки заказа.</summary>
    public sealed record OrderDeliveryDate : ValueObject<OrderDeliveryDate, DateTime>, IValueObject<OrderDeliveryDate, DateTime>
    {
        internal OrderDeliveryDate(DateTime value) : base(value) { }

        /// <summary>Создаёт OrderDeliveryDate с проверкой (не null/по умолчанию).</summary>
        public static OrderDeliveryDate FromValue(DateTime value)
        {
            ValueNullException.ThrowIfNullOrDefault(value, nameof(OrderDeliveryDate));

            return new(value);
        }

        /// <summary>Значение по умолчанию — через 7 дней от текущей даты.</summary>
        public static OrderDeliveryDate Default => new(DateTime.Now.AddDays(7));
    }
}