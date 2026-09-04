using Domain.ValueObjects.ValueObject;
using Shared.Types.Exceptions.Validation;

namespace Domain.ValueObjects.Categories
{
    /// <summary>ValueObject для идентификатора категории.</summary>
    public sealed record CategoryId : ValueObject<CategoryId, long>, IValueObject<CategoryId, long>
    {
        internal CategoryId(long value) : base(value) { }

        /// <summary>Создаёт экземпляр CategoryId с проверкой диапазона (> = 1).</summary>
        public static CategoryId FromValue(long value)
        {
            ValueOutOfRangeException.ThrowIfLess(value, nameof(CategoryId), 1);

            return new(value);
        }
    }
}