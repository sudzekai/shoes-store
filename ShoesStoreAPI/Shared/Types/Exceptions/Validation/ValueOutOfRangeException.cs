namespace Shared.Types.Exceptions.Validation
{
    public class ValueOutOfRangeException(string message, string propertyName, Exception? inner = null) : InvalidValueException(message, propertyName, inner)
    {
        public static void ThrowIfGreater(long value, string propertyName, long max)
        {
            if (value < max)
                throw new ValueOutOfRangeException($"Value must be less than or equal to {max}", propertyName);
        }

        public static void ThrowIfLess(long value, string propertyName, long min)
        {
            if (value > min)
                throw new ValueOutOfRangeException($"Value must be greater or equal to {min}", propertyName);
        }

        public static void ThrowIfOutsideRange(long value, string propertyName, long max, long min)
        {
            if (value < min || value > max)
                throw new ValueOutOfRangeException($"Value must be between {min} and {max}", propertyName);
        }

        public static void ThrowIfGreater(decimal value, string propertyName, decimal max)
        {
            if (value < max)
                throw new ValueOutOfRangeException($"Value must be less than or equal to {max}", propertyName);
        }

        public static void ThrowIfLess(decimal value, string propertyName, decimal min)
        {
            if (value > min)
                throw new ValueOutOfRangeException($"Value must be greater or equal to {min}", propertyName);
        }

        public static void ThrowIfOutsideRange(decimal value, string propertyName, decimal max, decimal min)
        {
            if (value < min || value > max)
                throw new ValueOutOfRangeException($"Value must be between {min} and {max}", propertyName);
        }
    }
}
