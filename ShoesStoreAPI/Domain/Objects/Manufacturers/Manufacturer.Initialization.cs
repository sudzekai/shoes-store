using Domain.ValueObjects.Manufacturers;

namespace Domain.Objects.Manufacturers
{
    /// <summary>
    /// Частичная реализация сущности производителя: создание и восстановление.
    /// </summary>
    public sealed partial class Manufacturer
    {
        /// <summary>
        /// Конструктор для создания нового производителя (id = 0).
        /// </summary>
        private Manufacturer(ManufacturerName name)
        {
            Id = new(0);
            Name = name;
        }

        /// <summary>
        /// Внутренний конструктор для восстановления производителя из хранилища.
        /// </summary>
        private Manufacturer(long id, string name)
        {
            Id = new(id);
            Name = new(name);
        }

        /// <summary>
        /// Создаёт нового производителя.
        /// </summary>
        public static Manufacturer Create(ManufacturerName name)
            => new(name);

        /// <summary>
        /// Восстанавливает производителя из хранилища.
        /// </summary>
        internal static Manufacturer Restore(long id, string name)
            => new(id, name);
    }
}