using Microsoft.EntityFrameworkCore;
using StoreData.Data;
using StoreData.Dto;
using StoreData.Models;

namespace StoreData.Services
{
    public sealed class CatalogService(ShoesStoreContext db)
    {
        /// <summary>Показывает товары с учётом поиска и фильтров.</summary>
        public Task<List<ProductDto>> ListAsync(ProductFilter filter, CancellationToken ct = default)
        {
            var products = db.Products.AsNoTracking();
            if (!string.IsNullOrWhiteSpace(filter.Search))
            {
                var search = filter.Search.Trim().ToLowerInvariant();
                products = products.Where(product => product.Description.ToLower().Contains(search));
            }

            if (filter.ManufacturerId is long manufacturerId)
                products = products.Where(product => product.ManufacturerId == manufacturerId);

            if (filter.MaxPrice is decimal maxPrice)
                products = products.Where(product => product.Price <= maxPrice);

            if (filter.DiscountOnly)
                products = products.Where(product => product.DiscountPercent > 0);

            if (filter.InStockOnly)
                products = products.Where(product => product.Quantity > 0);

            var sorted = filter.Sort switch
            {
                ProductSort.Supplier => products.OrderBy(product => product.Supplier.Name),
                ProductSort.Price => products.OrderBy(product => product.Price),
                ProductSort.PriceDescending => products.OrderByDescending(product => product.Price),
                _ => products.OrderBy(product => product.Name)
            };

            return SelectProducts(sorted.ThenBy(product => product.Id)).ToListAsync(ct);
        }

        /// <summary>Ищет товар по артикулу.</summary>
        public Task<ProductDto?> FindAsync(string article, CancellationToken ct = default) =>
            SelectProducts(db.Products.AsNoTracking().Where(product => product.Article == article))
                .SingleOrDefaultAsync(ct);

        /// <summary>Загружает списки для выбора.</summary>
        public async Task<CatalogOptionsDto> GetOptionsAsync(CancellationToken ct = default) =>
            new(
                await db.Categories.OrderBy(x => x.Name).Select(x => new LookupDto(x.Id, x.Name)).ToListAsync(ct),
                await db.Manufacturers.OrderBy(x => x.Name).Select(x => new LookupDto(x.Id, x.Name)).ToListAsync(ct),
                await db.Units.OrderBy(x => x.Name).Select(x => new LookupDto(x.Id, x.Name)).ToListAsync(ct),
                await db.Suppliers.OrderBy(x => x.Name).Select(x => new LookupDto(x.Id, x.Name)).ToListAsync(ct));

        /// <summary>Подставляет названия вместо номеров.</summary>
        private IQueryable<ProductDto> SelectProducts(IQueryable<Product> products) =>
            products.Select(product => new ProductDto(
                product.Id, product.Article, product.Name, product.Description, product.Quantity,
                product.DiscountPercent, product.Price, product.PhotoFileName,
                new(product.CategoryId, product.Category.Name),
                new(product.ManufacturerId, product.Manufacturer.Name),
                new(product.UnitId, product.Unit.Name),
                new(product.SupplierId, product.Supplier.Name)));
    }
}
