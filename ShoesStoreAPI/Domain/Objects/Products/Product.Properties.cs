using Domain.ValueObjects.Categories;
using Domain.ValueObjects.Manufacturers;
using Domain.ValueObjects.Products;
using Domain.ValueObjects.Suppliers;
using Domain.ValueObjects.Units;

namespace Domain.Objects.Products
{
    public sealed partial class Product
    {
        public ProductId Id { get; private set; }

        public CategoryId CategoryId { get; private set; }
        
        public ManufacturerId ManufacturerId { get; private set; }

        public UnitId UnitId { get; private set; }

        public SupplierId SupplierId { get; private set; }
        
        public ProductArticle Article { get; private set; }
        
        public ProductName Name { get; private set; }
        
        public ProductDescription Description { get; private set; }

        public ProductQuantity Quantity { get; private set; }
        
        public ProductDiscountPercent DiscountPercent { get; private set; }

        public ProductPrice Price { get; private set; }

        public ProductPhotoFileName PhotoFileName { get; private set; }

        public void ChangeCategoryId(CategoryId categoryId)
            => CategoryId = categoryId;

        public void ChangeManufacturerId(ManufacturerId manufacturerId)
            => ManufacturerId = manufacturerId;

        public void ChangeUnitId(UnitId unitId)
            => UnitId = unitId;

        public void ChangeSupplierId(SupplierId supplierId)
            => SupplierId = supplierId;

        public void ChangeArticle(ProductArticle article)
            => Article = article;

        public void ChangeName(ProductName name)
            => Name = name;

        public void ChangeDescription(ProductDescription description)
            => Description = description;

        public void ChangeQuantity(ProductQuantity quantity)
            => Quantity = quantity;

        public void ChangeDiscountPercent(ProductDiscountPercent discountPercent)
            => DiscountPercent = discountPercent;

        public void ChangePrice(ProductPrice price)
            => Price = price;

        public void ChangePhotoFileName(ProductPhotoFileName photoFileName)
            => PhotoFileName = photoFileName;
    }
}
