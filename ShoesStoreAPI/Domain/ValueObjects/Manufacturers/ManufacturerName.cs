using Domain.ValueObjects.ValueObject;
using Shared.Types.Exceptions.Validation;

namespace Domain.ValueObjects.Manufacturers
{
    /// <summary>ValueObject для названия производителя.</summary>
    public sealed record ManufacturerName : ValueObject<ManufacturerName, string>, IValueObject<ManufacturerName, string>
    {
        internal ManufacturerName(string value) : base(value) { }

        /// <summary>Создаёт ManufacturerName с валидацией (не пустое, длина ≤ 50).</summary>
        public static ManufacturerName FromValue(string value)
        {
            var name = nameof(ManufacturerName);

            ValueNullException.ThrowIfNullOrWhiteSpace(value, name);
            ValueLengthOutOfRangeException.ThrowIfGreaterThan(value, name, 50);

            return new(value);
        }
    }
}