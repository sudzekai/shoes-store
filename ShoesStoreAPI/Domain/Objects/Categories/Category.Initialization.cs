using Domain.ValueObjects.Categories;

namespace Domain.Objects.Categories
{
    /// <summary>
    /// Частичная реализация сущности категории: создание и восстановление.
    /// </summary>
    public sealed partial class Category
    {
        /// <summary>
        /// Конструктор для создания новой категории в домене (id устанавливается как 0 — новый).
        /// </summary>
        private Category(CategoryName name)
        {
            Id = new(0);
            Name = name;
        }

        /// <summary>
        /// Внутренний конструктор для восстановления категории из хранилища (с указанным id).
        /// </summary>
        private Category(long id, string name)
        {
            Id = new(id);
            Name = new(name);
        }

        /// <summary>
        /// Создаёт новую категорию с указанным именем.
        /// </summary>
        public static Category Create(CategoryName name)
            => new(name);

        /// <summary>
        /// Восстанавливает категорию из хранилища по id и имени.
        /// </summary>
        internal static Category Restore(long id, string name)
            => new(id, name);
    }
}