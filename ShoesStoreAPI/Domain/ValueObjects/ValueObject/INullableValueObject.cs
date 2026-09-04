namespace Domain.ValueObjects.ValueObject
{
    public interface INullableValueObject<TSelf, TValue>
    {
        static abstract TSelf FromValue(TValue value);
    }
}
