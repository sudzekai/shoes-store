using Domain.ValueObjects.ValueObject;
using Shared.Types.Exceptions.Validation;

namespace Domain.ValueObjects.Users
{
    public sealed record UserId : ValueObject<UserId, long>, IValueObject<UserId, long>
    {
        internal UserId(long value) : base(value) { }

        public static UserId FromValue(long value)
        {
            ValueOutOfRangeException.ThrowIfLess(value, nameof(UserId), 1);

            return new(value);
        }
    }
}
