using Domain.ValueObjects.ValueObject;
using Shared.Types.Exceptions.Validation;

namespace Domain.ValueObjects.Manufacturers
{
    /// <summary>ValueObject для идентификатора производителя.</summary>
    public sealed record ManufacturerId : ValueObject<ManufacturerId, long>, IValueObject<ManufacturerId, long>
    {
        internal ManufacturerId(long value) : base(value) { }

        /// <summary>Создаёт ManufacturerId с проверкой (value >= 1).</summary>
        public static ManufacturerId FromValue(long value)
        {
            ValueOutOfRangeException.ThrowIfLess(value, nameof(ManufacturerId), 1);

            return new(value);
        }
    }
}