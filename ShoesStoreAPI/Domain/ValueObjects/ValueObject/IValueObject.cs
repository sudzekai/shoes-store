namespace Domain.ValueObjects.ValueObject
{
    /// <summary>Интерфейс для value object с фабричным методом FromValue.</summary>
    public interface IValueObject<TSelf, TValue>
    {
        static abstract TSelf FromValue(TValue value);
    }
}