using Domain.ValueObjects.ValueObject;
using Shared.Types.Exceptions.Validation;

namespace Domain.ValueObjects.Statuses
{
    /// <summary>ValueObject для названия статуса.</summary>
    public sealed record StatusName : ValueObject<StatusName, string>, IValueObject<StatusName, string>
    {
        internal StatusName(string value) : base(value) { }

        /// <summary>Создаёт StatusName (не пустое, длина ≤ 25).</summary>
        public static StatusName FromValue(string value)
        {
            var name = nameof(StatusName);

            ValueNullException.ThrowIfNullOrWhiteSpace(value, name);
            ValueLengthOutOfRangeException.ThrowIfGreaterThan(value, name, 25);

            return new(value);
        }
    }
}