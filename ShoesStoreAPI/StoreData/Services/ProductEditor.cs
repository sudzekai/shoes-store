using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using StoreData.Data;
using StoreData.Dto;
using StoreData.Models;

namespace StoreData.Services
{
    public sealed class ProductEditor(ShoesStoreContext db)
    {
        /// <summary>Добавляет товар.</summary>
        public async Task AddAsync(ProductEditDto input, CancellationToken ct = default)
        {
            var product = new Product();
            await ApplyAsync(product, input, ct);

            db.Products.Add(product);
            await db.SaveChangesAsync(ct);
        }

        /// <summary>Сохраняет изменения товара.</summary>
        public async Task<bool> UpdateAsync(string article, ProductEditDto input, CancellationToken ct = default)
        {
            var product = await db.Products.SingleOrDefaultAsync(x => x.Article == article, ct);
            if (product is null)
                return false;

            await ApplyAsync(product, input, ct);
            await db.SaveChangesAsync(ct);

            return true;
        }

        /// <summary>Удаляет товар, если его нет в заказах.</summary>
        public async Task<bool> DeleteAsync(string article, CancellationToken ct = default)
        {
            var product = await db.Products.SingleOrDefaultAsync(x => x.Article == article, ct);
            if (product is null)
                return false;

            if (await db.OrderItems.AnyAsync(x => x.ProductId == product.Id, ct))
                throw new InvalidOperationException("Этот товар уже есть в заказах.");

            db.Products.Remove(product);
            await db.SaveChangesAsync(ct);

            return true;
        }

        /// <summary>Проверяет и заполняет поля товара.</summary>
        private async Task ApplyAsync(Product product, ProductEditDto input, CancellationToken ct)
        {
            Validator.ValidateObject(input, new ValidationContext(input), validateAllProperties: true);

            if (!await db.Categories.AnyAsync(x => x.Id == input.CategoryId, ct)
                || !await db.Manufacturers.AnyAsync(x => x.Id == input.ManufacturerId, ct)
                || !await db.Units.AnyAsync(x => x.Id == input.UnitId, ct)
                || !await db.Suppliers.AnyAsync(x => x.Id == input.SupplierId, ct))
                throw new ValidationException("Проверьте категорию, производителя, единицу и поставщика.");

            if (await db.Products.AnyAsync(x => x.Article == input.Article && x.Id != product.Id, ct))
                throw new ValidationException("Товар с таким артикулом уже есть.");

            if (input.PhotoFileName?.IndexOfAny(['/', '\\']) >= 0)
                throw new ValidationException("Укажите только имя файла.");

            product.Article = input.Article;
            product.Name = input.Name;
            product.Description = input.Description;
            product.Quantity = input.Quantity;
            product.DiscountPercent = input.DiscountPercent;
            product.Price = input.Price;
            product.PhotoFileName = input.PhotoFileName;
            product.CategoryId = input.CategoryId;
            product.ManufacturerId = input.ManufacturerId;
            product.UnitId = input.UnitId;
            product.SupplierId = input.SupplierId;
        }
    }
}
