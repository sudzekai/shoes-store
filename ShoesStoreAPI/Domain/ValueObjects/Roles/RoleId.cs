using Domain.ValueObjects.ValueObject;
using Shared.Types.Exceptions.Validation;

namespace Domain.ValueObjects.Roles
{
    /// <summary>ValueObject для идентификатора роли.</summary>
    public sealed record RoleId : ValueObject<RoleId, long>, IValueObject<RoleId, long>
    {
        internal RoleId(long value) : base(value) { }

        /// <summary>Создаёт RoleId (value >= 1).</summary>
        public static RoleId FromValue(long value)
        {
            ValueOutOfRangeException.ThrowIfLess(value, nameof(RoleId), 1);

            return new(value);
        }
    }
}