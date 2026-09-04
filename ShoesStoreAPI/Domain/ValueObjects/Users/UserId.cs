using Domain.ValueObjects.ValueObject;
using Shared.Types.Exceptions.Validation;

namespace Domain.ValueObjects.Users
{
    /// <summary>ValueObject для идентификатора пользователя.</summary>
    public sealed record UserId : ValueObject<UserId, long>, IValueObject<UserId, long>
    {
        internal UserId(long value) : base(value) { }

        /// <summary>Создаёт UserId (value >= 1).</summary>
        public static UserId FromValue(long value)
        {
            ValueOutOfRangeException.ThrowIfLess(value, nameof(UserId), 1);

            return new(value);
        }
    }
}