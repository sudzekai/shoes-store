using Domain.ValueObjects.Categories;

namespace Domain.Objects.Categories
{
    /// <summary>
    /// Частичная реализация сущности категории: свойства и операции изменения.
    /// </summary>
    public sealed partial class Category
    {
        /// <summary>
        /// Идентификатор категории.
        /// </summary>
        public CategoryId Id { get; private set; }

        /// <summary>
        /// Название категории.
        /// </summary>
        public CategoryName Name { get; private set; }

        /// <summary>
        /// Изменить название категории.
        /// </summary>
        public void ChangeName(CategoryName name)
            => Name = name;
    }
}