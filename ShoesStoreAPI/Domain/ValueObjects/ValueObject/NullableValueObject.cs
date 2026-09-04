namespace Domain.ValueObjects.ValueObject
{
    /// <summary>Базовый nullable value object; хранит nullable значение.</summary>
    public abstract record NullableValueObject<TSelf, TValue>
        where TSelf : NullableValueObject<TSelf, TValue>
    {
        /// <summary>Значение value object (может быть null).</summary>
        public virtual TValue? Value { get; init; }

        protected NullableValueObject(TValue? value)
            => Value = value;
    }
}