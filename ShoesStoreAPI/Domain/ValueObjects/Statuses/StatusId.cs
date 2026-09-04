using Domain.ValueObjects.ValueObject;
using Shared.Types.Exceptions.Validation;

namespace Domain.ValueObjects.Statuses
{
    public sealed record StatusId : ValueObject<StatusId, long>, IValueObject<StatusId, long>
    {
        internal StatusId(long value) : base(value) { }

        public static StatusId FromValue(long value)
        {
            ValueOutOfRangeException.ThrowIfLess(value, nameof(StatusId), 1);

            return new(value);
        }
    }
}
