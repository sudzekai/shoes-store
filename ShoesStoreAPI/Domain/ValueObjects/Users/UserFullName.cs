using Domain.ValueObjects.ValueObject;
using Shared.Types.Exceptions.Validation;

namespace Domain.ValueObjects.Users
{
    /// <summary>ValueObject для полного имени пользователя.</summary>
    public sealed record UserFullName : ValueObject<UserFullName, string>, IValueObject<UserFullName, string>
    {
        internal UserFullName(string value) : base(value) { }

        /// <summary>Создаёт UserFullName (не пустое, длина ≤ 255).</summary>
        public static UserFullName FromValue(string value)
        {
            var name = nameof(UserFullName);

            ValueNullException.ThrowIfNullOrWhiteSpace(value, name);
            ValueLengthOutOfRangeException.ThrowIfGreaterThan(value, name, 255);

            return new(value);
        }
    }
}