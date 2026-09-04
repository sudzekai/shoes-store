namespace Shared.Types.Exceptions.Validation
{
    public class InvalidValueException(string message, string propertyName, Exception? inner = null) : Exception($"{message.TrimEnd('.')}. Parameter: {propertyName}", inner) { }
}
