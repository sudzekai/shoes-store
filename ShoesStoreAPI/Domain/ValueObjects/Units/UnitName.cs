using Domain.ValueObjects.ValueObject;
using Shared.Types.Exceptions.Validation;

namespace Domain.ValueObjects.Units
{
    public sealed record UnitName : ValueObject<UnitName, string>, IValueObject<UnitName, string>
    {
        internal UnitName(string value) : base(value) { }

        public static UnitName FromValue(string value)
        {
            var name = nameof(UnitName);

            ValueNullException.ThrowIfNullOrWhiteSpace(value, name);
            ValueLengthOutOfRangeException.ThrowIfGreaterThan(value, name, 10);

            return new(value);
        }
    }
}
