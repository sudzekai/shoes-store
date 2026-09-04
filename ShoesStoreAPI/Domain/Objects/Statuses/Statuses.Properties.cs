using Domain.ValueObjects.Statuses;

namespace Domain.Objects.Statuses
{
    /// <summary>Частичная реализация статуса: свойства и операции изменения.</summary>
    public sealed partial class Status
    {
        /// <summary>Идентификатор статуса.</summary>
        public StatusId Id { get; private set; }

        /// <summary>Название статуса.</summary>
        public StatusName Name { get; private set; }

        /// <summary>Изменить название статуса.</summary>
        public void ChangeName(StatusName name)
            => Name = name;
    }
}