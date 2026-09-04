using Domain.ValueObjects.Statuses;

namespace Domain.Objects.Statuses
{
    public sealed partial class Status
    {
        private Status(StatusName name)
        {
            Id = new(0);
            Name = name;
        }

        private Status(long id, string name)
        {
            Id = new(id);
            Name = new(name);
        }

        public static Status Create(StatusName name)
            => new(name);

        internal static Status Restore(long id, string name)
            => new(id, name);
    }
}
