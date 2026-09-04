using Domain.ValueObjects.ValueObject;
using Shared.Types.Exceptions.Validation;

namespace Domain.ValueObjects.Roles
{
    public sealed record RoleId : ValueObject<RoleId, long>, IValueObject<RoleId, long>
    {
        internal RoleId(long value) : base(value) { }

        public static RoleId FromValue(long value)
        {
            ValueOutOfRangeException.ThrowIfLess(value, nameof(RoleId), 1);

            return new(value);
        }
    }
}
