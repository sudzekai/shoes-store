using Domain.ValueObjects.Manufacturers;

namespace Domain.Objects.Manufacturers
{
    /// <summary>
    /// Частичная реализация сущности производителя: свойства и операции изменения.
    /// </summary>
    public sealed partial class Manufacturer
    {
        /// <summary>
        /// Идентификатор производителя.
        /// </summary>
        public ManufacturerId Id { get; private set; }

        /// <summary>
        /// Название производителя.
        /// </summary>
        public ManufacturerName Name { get; private set; }

        /// <summary>
        /// Изменить название производителя.
        /// </summary>
        public void ChangeName(ManufacturerName name)
            => Name = name;
    }
}