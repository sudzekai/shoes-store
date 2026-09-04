using Domain.ValueObjects.ValueObject;
using Shared.Types.Exceptions.Validation;

namespace Domain.ValueObjects.Categories
{
    public sealed record CategoryId : ValueObject<CategoryId, long>, IValueObject<CategoryId, long>
    {
        internal CategoryId(long value) : base(value) { }

        public static CategoryId FromValue(long value)
        {
            ValueOutOfRangeException.ThrowIfLess(value, nameof(CategoryId), 1);

            return new(value);
        }
    }
}
