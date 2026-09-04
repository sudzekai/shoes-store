namespace Domain.ValueObjects.ValueObject
{
    /// <summary>Интерфейс для nullable value object с фабричным методом FromValue.</summary>
    public interface INullableValueObject<TSelf, TValue>
    {
        static abstract TSelf FromValue(TValue value);
    }
}