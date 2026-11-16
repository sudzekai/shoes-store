using System.ComponentModel.DataAnnotations;

namespace StoreData.Dto
{
    public sealed record LookupDto(long Id, string Name);

    public sealed record CatalogOptionsDto(
        List<LookupDto> Categories, List<LookupDto> Manufacturers,
        List<LookupDto> Units, List<LookupDto> Suppliers);

    public enum ProductSort { Name, Supplier, Price, PriceDescending }

    public sealed record ProductFilter(
        string? Search = null, long? ManufacturerId = null, decimal? MaxPrice = null,
        bool DiscountOnly = false, bool InStockOnly = false, ProductSort Sort = ProductSort.Name);

    public sealed record ProductDto(
        long Id, string Article, string Name, string Description, int Quantity,
        short DiscountPercent, decimal Price, string? PhotoFileName,
        LookupDto Category, LookupDto Manufacturer, LookupDto Unit, LookupDto Supplier)
    {
        public decimal FinalPrice => Math.Round(Price * (100 - DiscountPercent) / 100, 2, MidpointRounding.AwayFromZero);
    }

    public sealed record ProductEditDto(
        [Required, StringLength(6)] string Article,
        [Required, StringLength(50)] string Name,
        [Required, StringLength(255)] string Description,
        [Range(0, int.MaxValue)] int Quantity,
        [Range(0, 100)] short DiscountPercent,
        [Range(typeof(decimal), "0", "9999999999999999.99", ParseLimitsInInvariantCulture = true)] decimal Price,
        [StringLength(255)] string? PhotoFileName,
        long CategoryId, long ManufacturerId, long UnitId, long SupplierId);
}
