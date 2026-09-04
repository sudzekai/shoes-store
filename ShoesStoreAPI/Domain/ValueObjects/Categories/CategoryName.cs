using Domain.ValueObjects.ValueObject;
using Shared.Types.Exceptions.Validation;

namespace Domain.ValueObjects.Categories
{
    public sealed record CategoryName : ValueObject<CategoryName, string>, IValueObject<CategoryName, string>
    {
        internal CategoryName(string value) : base(value) { }

        public static CategoryName FromValue(string value)
        {
            var name = nameof(CategoryName);
            
            ValueNullException.ThrowIfNullOrWhiteSpace(value, name);
            ValueLengthOutOfRangeException.ThrowIfGreaterThan(value, name, 50);

            return new(value);
        }
    }
}
