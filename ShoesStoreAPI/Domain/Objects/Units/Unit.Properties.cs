using Domain.ValueObjects.Units;

namespace Domain.Objects.Units
{
    /// <summary>Частичная реализация единицы измерения: свойства и операции изменения.</summary>
    public sealed partial class Unit
    {
        /// <summary>Идентификатор единицы измерения.</summary>
        public UnitId Id { get; private set; }

        /// <summary>Название единицы измерения.</summary>
        public UnitName Name { get; private set; }

        /// <summary>Изменить название единицы измерения.</summary>
        public void ChangeName(UnitName name)
            => Name = name;
    }
}