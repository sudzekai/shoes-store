namespace Domain.ValueObjects.ValueObject
{
    public abstract record NullableValueObject<TSelf, TValue>
        where TSelf : NullableValueObject<TSelf, TValue>
    {
        public virtual TValue? Value { get; init; }

        protected NullableValueObject(TValue? value)
            => Value = value;
    }
}
