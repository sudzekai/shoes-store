using Domain.ValueObjects.Categories;
using Domain.ValueObjects.Manufacturers;
using Domain.ValueObjects.Products;
using Domain.ValueObjects.Suppliers;
using Domain.ValueObjects.Units;

namespace Domain.Objects.Products
{
    public sealed partial class Product
    {
        private Product(CategoryId categoryId, ManufacturerId manufacturerId, UnitId unitId, SupplierId supplierId, ProductArticle article, ProductName name, ProductDescription description, ProductQuantity quantity, ProductDiscountPercent discountPercent, ProductPrice price, ProductPhotoFileName photoFileName)
        {
            Id = new(0);
            CategoryId = categoryId;
            ManufacturerId = manufacturerId;
            UnitId = unitId;
            SupplierId = supplierId;
            Article = article;
            Name = name;
            Description = description;
            Quantity = quantity;
            DiscountPercent = discountPercent;
            Price = price;
            PhotoFileName = photoFileName;
        }

        private Product(long id, long categoryId, long manufacturerId, long unitId, long supplierId, string article, string name, string description, short quantity, short discountPercent, decimal price, string photoFileName)
        {
            Id = new(id);
            CategoryId = new(categoryId);
            ManufacturerId = new(manufacturerId);
            UnitId = new(unitId);
            SupplierId = new(supplierId);
            Article = new(article);
            Name = new(name);
            Description = new(description);
            Quantity = new(quantity);
            DiscountPercent = new(discountPercent);
            Price = new(price);
            PhotoFileName = new(photoFileName);
        }

        public static Product Create(CategoryId categoryId, ManufacturerId manufacturerId, UnitId unitId, SupplierId supplierId, ProductArticle article, ProductName name, ProductDescription description, ProductQuantity quantity, ProductDiscountPercent discountPercent, ProductPrice price, ProductPhotoFileName photoFileName)
            => new(categoryId, manufacturerId, unitId, supplierId, article, name, description, quantity, discountPercent, price, photoFileName);

        internal static Product Restore(long id, long categoryId, long manufacturerId, long unitId, long supplierId, string article, string name, string description, short quantity, short discountPercent, decimal price, string photoFileName)
            => new(id, categoryId, manufacturerId, unitId, supplierId, article, name, description, quantity, discountPercent, price, photoFileName);
    }
}