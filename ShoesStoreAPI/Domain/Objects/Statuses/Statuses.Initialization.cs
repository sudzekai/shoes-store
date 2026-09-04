using Domain.ValueObjects.Statuses;

namespace Domain.Objects.Statuses
{
    /// <summary>Частичная реализация статуса: создание и восстановление.</summary>
    public sealed partial class Status
    {
        /// <summary>Создаёт новый статус (id = 0).</summary>
        private Status(StatusName name)
        {
            Id = new(0);
            Name = name;
        }

        /// <summary>Восстанавливает статус с указанным id.</summary>
        private Status(long id, string name)
        {
            Id = new(id);
            Name = new(name);
        }

        /// <summary>Создать статус.</summary>
        public static Status Create(StatusName name)
            => new(name);

        /// <summary>Восстановить статус.</summary>
        internal static Status Restore(long id, string name)
            => new(id, name);
    }
}