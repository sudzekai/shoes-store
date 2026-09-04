using Domain.ValueObjects.Categories;

namespace Domain.Objects.Categories
{
    public sealed partial class Category
    {
        private Category(CategoryName name)
        {
            Id = new(0);
            Name = name;
        }

        private Category(long id, string name)
        {
            Id = new(id);
            Name = new(name);
        }

        public static Category Create(CategoryName name)
            => new(name);

        internal static Category Restore(long id, string name)
            => new(id, name);
    }
}
