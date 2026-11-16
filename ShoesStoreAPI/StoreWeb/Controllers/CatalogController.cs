using Microsoft.AspNetCore.Mvc;
using StoreData.Dto;
using StoreData.Services;

namespace StoreWeb.Controllers
{
    public sealed record CatalogPage(ProductFilter Filter, List<ProductDto> Products, List<LookupDto> Manufacturers);

    public sealed class CatalogController(CatalogService catalog) : Controller
    {
        /// <summary>Показывает каталог и выбранные фильтры.</summary>
        [HttpGet("/")]
        public async Task<IActionResult> IndexAsync([FromQuery] ProductFilter filter, CancellationToken ct)
        {
            var products = await catalog.ListAsync(filter, ct);
            var options = await catalog.GetOptionsAsync(ct);
            return View("Index", new CatalogPage(filter, products, options.Manufacturers));
        }
    }
}
