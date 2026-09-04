namespace Shared.Types.Exceptions.Validation
{
    public class ValueLengthOutOfRangeException(string message, string propertyName, Exception? inner = null) : InvalidValueException(message, propertyName, inner)
    {
        public static void ThrowIfGreaterThan(string value, string propertyName, int max)
        {
            if (value.Length > max)
                throw new ValueLengthOutOfRangeException(
                    $"Value length must be less than or equal to {max}.",
                    propertyName);
        }

        public static void ThrowIfLessThan(string value, string propertyName, int min)
        {
            if (value.Length < min)
                throw new ValueLengthOutOfRangeException(
                    $"Value length must be greater than or equal to {min}.",
                    propertyName);
        }

        public static void ThrowIfNotEqual(string value, string propertyName, int expected)
        {
            if (value.Length != expected)
                throw new ValueLengthOutOfRangeException(
                    $"Value length must be equal to {expected}.",
                    propertyName);
        }

        public static void ThrowIfOutsideRange(string value, string propertyName, int min, int max)
        {
            if (value.Length < min || value.Length > max)
                throw new ValueLengthOutOfRangeException(
                    $"Value length must be between {min} and {max}.",
                    propertyName);
        }
    }
}
