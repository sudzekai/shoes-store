using Domain.ValueObjects.ValueObject;
using Shared.Types.Exceptions.Validation;

namespace Domain.ValueObjects.Users
{
    /// <summary>ValueObject для хеша пароля пользователя.</summary>
    public sealed record UserPasswordHash : ValueObject<UserPasswordHash, string>, IValueObject<UserPasswordHash, string>
    {
        internal UserPasswordHash(string value) : base(value) { }

        /// <summary>Создаёт UserPasswordHash (не пустой).</summary>
        public static UserPasswordHash FromValue(string value)
        {
            ValueNullException.ThrowIfNullOrWhiteSpace(value, nameof(UserPasswordHash));

            return new(value);
        }
    }
}