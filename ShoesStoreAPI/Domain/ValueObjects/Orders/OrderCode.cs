using Domain.ValueObjects.ValueObject;
using Shared.Types.Exceptions.Validation;

namespace Domain.ValueObjects.Orders
{
    /// <summary>ValueObject для кода заказа.</summary>
    public sealed record OrderCode : ValueObject<OrderCode, short>, IValueObject<OrderCode, short>
    {
        internal OrderCode(short value) : base(value) { }

        /// <summary>Создаёт OrderCode с проверкой диапазона (100..999).</summary>
        public static OrderCode FromValue(short value)
        {
            ValueOutOfRangeException.ThrowIfOutsideRange(value, nameof(OrderCode), 999, 100);

            return new(value);
        }
    }
}