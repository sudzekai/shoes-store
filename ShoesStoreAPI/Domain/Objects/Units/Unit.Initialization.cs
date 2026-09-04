using Domain.ValueObjects.Units;

namespace Domain.Objects.Units
{
    /// <summary>Частичная реализация единицы измерения: создание и восстановление.</summary>
    public sealed partial class Unit
    {
        /// <summary>Создаёт новую единицу (id = 0).</summary>
        private Unit(UnitName name)
        {
            Id = new(0);
            Name = name;
        }

        /// <summary>Восстанавливает единицу измерения из хранилища.</summary>
        private Unit(long id, string name)
        {
            Id = new(id);
            Name = new(name);
        }

        /// <summary>Создать единицу измерения.</summary>
        public static Unit Create(UnitName name)
            => new(name);

        /// <summary>Восстановить единицу измерения.</summary>
        internal static Unit Restore(long id, string name)
            => new(id, name);
    }
}