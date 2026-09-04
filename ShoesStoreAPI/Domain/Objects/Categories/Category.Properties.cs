using Domain.ValueObjects.Categories;

namespace Domain.Objects.Categories
{
    public sealed partial class Category
    {
        public CategoryId Id { get; private set; }

        public CategoryName Name { get; private set; }

        public void ChangeName(CategoryName name)
            => Name = name;
    }
}
