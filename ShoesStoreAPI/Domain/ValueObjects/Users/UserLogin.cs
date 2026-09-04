using Domain.ValueObjects.ValueObject;
using Shared.Types.Exceptions.Validation;
using System.Text.RegularExpressions;

namespace Domain.ValueObjects.Users
{
    public sealed partial record UserLogin : ValueObject<UserLogin, string>, IValueObject<UserLogin, string>
    {
        internal UserLogin(string value) : base(value) { }

        public static UserLogin FromValue(string value)
        {
            var name = nameof(UserLogin);

            ValueNullException.ThrowIfNullOrWhiteSpace(value, name);
            ValueLengthOutOfRangeException.ThrowIfGreaterThan(value, name, 255);
            ValueInvalidFormatException.ThrowIfNotMatch(value, name, EmailRegex());

            return new(value);
        }

        /// <summary>
        /// Регулярное выражение для валидации login как email адреса 
        /// Соответствует RFC 5322
        /// Источник: https://www.regular-expressions.info/email.html
        /// </summary>
        [GeneratedRegex("""
            \A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|"(?:
            [\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|
            \\[\x01-\x09\x0b\x0c\x0e-\x7f])*)@
            (?:(?:
            [a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+
            [a-z0-9](?:[a-z0-9-]*[a-z0-9])?|
            \[(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}
            (?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?|
            [a-z0-9-]*[a-z0-9]:
            (?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|
            \\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\])\z
            """, RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace, "ru-RU")]
        private static partial Regex EmailRegex();
    }
}
