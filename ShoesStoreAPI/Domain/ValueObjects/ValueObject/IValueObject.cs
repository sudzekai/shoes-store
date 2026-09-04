namespace Domain.ValueObjects.ValueObject
{
    public interface IValueObject<TSelf, TValue>
    {
        static abstract TSelf FromValue(TValue value);
    }
}
