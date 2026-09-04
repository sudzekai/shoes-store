using Domain.ValueObjects.ValueObject;
using Shared.Types.Exceptions.Validation;

namespace Domain.ValueObjects.Roles
{
    /// <summary>ValueObject для названия роли.</summary>
    public sealed record RoleName : ValueObject<RoleName, string>, IValueObject<RoleName, string>
    {
        internal RoleName(string value) : base(value) { }

        /// <summary>Создаёт RoleName (не пустое, длина ≤ 20).</summary>
        public static RoleName FromValue(string value)
        {
            var name = nameof(RoleName);

            ValueNullException.ThrowIfNullOrWhiteSpace(value, name);
            ValueLengthOutOfRangeException.ThrowIfGreaterThan(value, name, 20);

            return new(value);
        }
    }
}