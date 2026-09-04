using Domain.ValueObjects.ValueObject;
using Shared.Types.Exceptions.Validation;

namespace Domain.ValueObjects.Units
{
    public sealed record UnitId : ValueObject<UnitId, long>, IValueObject<UnitId, long>
    {
        internal UnitId(long value) : base(value) { }

        public static UnitId FromValue(long value)
        {
            ValueOutOfRangeException.ThrowIfLess(value, nameof(UnitId), 1);

            return new(value);
        }
    }
}
