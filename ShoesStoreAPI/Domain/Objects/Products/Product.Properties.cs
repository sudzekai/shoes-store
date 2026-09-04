using Domain.ValueObjects.Categories;
using Domain.ValueObjects.Manufacturers;
using Domain.ValueObjects.Products;
using Domain.ValueObjects.Suppliers;
using Domain.ValueObjects.Units;

namespace Domain.Objects.Products
{
    /// <summary>
    /// Частичная реализация сущности товара: свойства и операции изменения.
    /// </summary>
    public sealed partial class Product
    {
        /// <summary>Идентификатор товара.</summary>
        public ProductId Id { get; private set; }

        /// <summary>Идентификатор категории товара.</summary>
        public CategoryId CategoryId { get; private set; }

        /// <summary>Идентификатор производителя товара.</summary>
        public ManufacturerId ManufacturerId { get; private set; }

        /// <summary>Идентификатор единицы измерения.</summary>
        public UnitId UnitId { get; private set; }

        /// <summary>Идентификатор поставщика.</summary>
        public SupplierId SupplierId { get; private set; }

        /// <summary>Артикул товара.</summary>
        public ProductArticle Article { get; private set; }

        /// <summary>Название товара.</summary>
        public ProductName Name { get; private set; }

        /// <summary>Описание товара.</summary>
        public ProductDescription Description { get; private set; }

        /// <summary>Количество на складе.</summary>
        public ProductQuantity Quantity { get; private set; }

        /// <summary>Процент скидки.</summary>
        public ProductDiscountPercent DiscountPercent { get; private set; }

        /// <summary>Цена товара.</summary>
        public ProductPrice Price { get; private set; }

        /// <summary>Имя файла с фотографией товара (может быть null).</summary>
        public ProductPhotoFileName PhotoFileName { get; private set; }

        /// <summary>Изменить категорию товара.</summary>
        public void ChangeCategoryId(CategoryId categoryId)
            => CategoryId = categoryId;

        /// <summary>Изменить производителя товара.</summary>
        public void ChangeManufacturerId(ManufacturerId manufacturerId)
            => ManufacturerId = manufacturerId;

        /// <summary>Изменить единицу измерения.</summary>
        public void ChangeUnitId(UnitId unitId)
            => UnitId = unitId;

        /// <summary>Изменить поставщика.</summary>
        public void ChangeSupplierId(SupplierId supplierId)
            => SupplierId = supplierId;

        /// <summary>Изменить артикул.</summary>
        public void ChangeArticle(ProductArticle article)
            => Article = article;

        /// <summary>Изменить название.</summary>
        public void ChangeName(ProductName name)
            => Name = name;

        /// <summary>Изменить описание.</summary>
        public void ChangeDescription(ProductDescription description)
            => Description = description;

        /// <summary>Изменить количество на складе.</summary>
        public void ChangeQuantity(ProductQuantity quantity)
            => Quantity = quantity;

        /// <summary>Изменить процент скидки.</summary>
        public void ChangeDiscountPercent(ProductDiscountPercent discountPercent)
            => DiscountPercent = discountPercent;

        /// <summary>Изменить цену.</summary>
        public void ChangePrice(ProductPrice price)
            => Price = price;

        /// <summary>Изменить имя файла фотографии.</summary>
        public void ChangePhotoFileName(ProductPhotoFileName photoFileName)
            => PhotoFileName = photoFileName;
    }
}