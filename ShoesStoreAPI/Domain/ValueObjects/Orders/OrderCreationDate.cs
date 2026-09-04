using Domain.ValueObjects.ValueObject;
using Shared.Types.Exceptions.Validation;

namespace Domain.ValueObjects.Orders
{
    /// <summary>ValueObject для даты создания заказа.</summary>
    public sealed record OrderCreationDate : ValueObject<OrderCreationDate, DateTime>, IValueObject<OrderCreationDate, DateTime>
    {
        internal OrderCreationDate(DateTime value) : base(value) { }

        /// <summary>Создаёт OrderCreationDate с проверкой (не null/по умолчанию).</summary>
        public static OrderCreationDate FromValue(DateTime value)
        {
            ValueNullException.ThrowIfNullOrDefault(value, nameof(OrderCreationDate));

            return new(value);
        }

        /// <summary>Значение по умолчанию — текущее время.</summary>
        public static OrderCreationDate Default => new(DateTime.Now);
    }
}