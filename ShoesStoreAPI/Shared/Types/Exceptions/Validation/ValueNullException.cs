namespace Shared.Types.Exceptions.Validation
{
    public class ValueNullException(string message, string propertyName, Exception? inner = null) : InvalidValueException(message, propertyName, inner)
    {
        public static void ThrowIfNullOrWhiteSpace(string value, string propertyName)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ValueNullException("Value must not be null or white space", propertyName);
        }

        public static void ThrowIfNull(object? value, string propertyName)
        {
            if (value is null)
                throw new ValueNullException("Value must not be null", propertyName);
        }

        public static void ThrowIfNullOrDefault(object value, string propertyName)
        {
            if (value.Equals(default))
                throw new ValueNullException("Value must not be null or default", propertyName);
        }
    }
}
