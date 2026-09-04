using Domain.ValueObjects.ValueObject;
using Shared.Types.Exceptions.Validation;

namespace Domain.ValueObjects.Statuses
{
    public sealed record StatusName : ValueObject<StatusName, string>, IValueObject<StatusName, string>
    {
        internal StatusName(string value) : base(value) { }

        public static StatusName FromValue(string value)
        {
            var name = nameof(StatusName);

            ValueNullException.ThrowIfNullOrWhiteSpace(value, name);
            ValueLengthOutOfRangeException.ThrowIfGreaterThan(value, name, 25);

            return new(value);
        }
    }
}
