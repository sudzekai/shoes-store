using Domain.ValueObjects.Statuses;

namespace Domain.Objects.Statuses
{
    public sealed partial class Status
    {
        public StatusId Id { get; private set; }

        public StatusName Name { get; private set; }

        public void ChangeName(StatusName name)
            => Name = name;
    }
}
