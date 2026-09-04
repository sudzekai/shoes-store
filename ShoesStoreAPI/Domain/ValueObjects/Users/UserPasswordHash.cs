using Domain.ValueObjects.ValueObject;
using Shared.Types.Exceptions.Validation;

namespace Domain.ValueObjects.Users
{
    public sealed record UserPasswordHash : ValueObject<UserPasswordHash, string>, IValueObject<UserPasswordHash, string>
    {
        internal UserPasswordHash(string value) : base(value) { }

        public static UserPasswordHash FromValue(string value)
        {
            ValueNullException.ThrowIfNullOrWhiteSpace(value, nameof(UserPasswordHash));

            return new(value);
        }
    }
}
