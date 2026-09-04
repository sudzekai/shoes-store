using Domain.ValueObjects.ValueObject;
using Shared.Types.Exceptions.Validation;

namespace Domain.ValueObjects.Statuses
{
    /// <summary>ValueObject для идентификатора статуса.</summary>
    public sealed record StatusId : ValueObject<StatusId, long>, IValueObject<StatusId, long>
    {
        internal StatusId(long value) : base(value) { }

        /// <summary>Создаёт StatusId (value >= 1).</summary>
        public static StatusId FromValue(long value)
        {
            ValueOutOfRangeException.ThrowIfLess(value, nameof(StatusId), 1);

            return new(value);
        }
    }
}