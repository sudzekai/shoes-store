using Domain.ValueObjects.ValueObject;
using Shared.Types.Exceptions.Validation;

namespace Domain.ValueObjects.Units
{
    /// <summary>ValueObject для идентификатора единицы измерения.</summary>
    public sealed record UnitId : ValueObject<UnitId, long>, IValueObject<UnitId, long>
    {
        internal UnitId(long value) : base(value) { }

        /// <summary>Создаёт UnitId (value >= 1).</summary>
        public static UnitId FromValue(long value)
        {
            ValueOutOfRangeException.ThrowIfLess(value, nameof(UnitId), 1);

            return new(value);
        }
    }
}