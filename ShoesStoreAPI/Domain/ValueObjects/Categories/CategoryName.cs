using Domain.ValueObjects.ValueObject;
using Shared.Types.Exceptions.Validation;

namespace Domain.ValueObjects.Categories
{
    /// <summary>ValueObject для названия категории.</summary>
    public sealed record CategoryName : ValueObject<CategoryName, string>, IValueObject<CategoryName, string>
    {
        internal CategoryName(string value) : base(value) { }

        /// <summary>Создаёт CategoryName с валидацией (не пустое, длина ≤ 50).</summary>
        public static CategoryName FromValue(string value)
        {
            var name = nameof(CategoryName);

            ValueNullException.ThrowIfNullOrWhiteSpace(value, name);
            ValueLengthOutOfRangeException.ThrowIfGreaterThan(value, name, 50);

            return new(value);
        }
    }
}