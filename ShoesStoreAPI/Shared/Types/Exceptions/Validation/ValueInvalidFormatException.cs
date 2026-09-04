using System.Text.RegularExpressions;

namespace Shared.Types.Exceptions.Validation
{
    public class ValueInvalidFormatException(string message, string propertyName, Exception? inner = null) : InvalidValueException(message, propertyName, inner)
    {
        public static void ThrowIfNotMatch(string value, string propertyName, Regex pattern)
        {
            if (!pattern.IsMatch(value))
                throw new ValueInvalidFormatException($"Value must match pattern \"{pattern}\"", propertyName);
        }
    }
}
