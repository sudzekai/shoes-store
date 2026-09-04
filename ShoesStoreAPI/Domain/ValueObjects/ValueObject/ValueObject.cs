namespace Domain.ValueObjects.ValueObject
{
    /// <summary>Базовый value object; хранит значение.</summary>
    public abstract record ValueObject<TSelf, TValue>
        where TSelf : ValueObject<TSelf, TValue>
    {
        /// <summary>Значение value object.</summary>
        public virtual TValue Value { get; init; }

        protected ValueObject(TValue value)
            => Value = value;
    }
}