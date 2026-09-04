namespace Domain.ValueObjects.ValueObject
{
    public abstract record ValueObject<TSelf, TValue>
        where TSelf : ValueObject<TSelf, TValue>
    {
        public virtual TValue Value { get; init; }

        protected ValueObject(TValue value)
            => Value = value;
    }
}
