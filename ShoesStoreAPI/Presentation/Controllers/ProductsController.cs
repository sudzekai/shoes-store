using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreData.Dto;
using StoreData.Services;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/products")]
    public sealed class ProductsController(CatalogService catalog, ProductEditor editor) : ControllerBase
    {
        /// <summary>Показывает список товаров.</summary>
        [HttpGet]
        public Task<List<ProductDto>> ListAsync([FromQuery] ProductFilter filter, CancellationToken ct) =>
            catalog.ListAsync(filter, ct);

        /// <summary>Показывает списки для выбора.</summary>
        [HttpGet("options")]
        public Task<CatalogOptionsDto> OptionsAsync(CancellationToken ct) => catalog.GetOptionsAsync(ct);

        /// <summary>Показывает товар по артикулу.</summary>
        [HttpGet("{article}", Name = "ProductByArticle")]
        public async Task<ActionResult<ProductDto>> FindAsync(string article, CancellationToken ct)
        {
            var product = await catalog.FindAsync(article, ct);
            return product is null ? NotFound() : Ok(product);
        }

        /// <summary>Добавляет товар.</summary>
        [Authorize(Roles = "Администратор,Менеджер")]
        [HttpPost]
        public async Task<IActionResult> AddAsync(ProductEditDto input, CancellationToken ct)
        {
            try
            {
                await editor.AddAsync(input, ct);
                return CreatedAtRoute("ProductByArticle", new { article = input.Article }, null);
            }
            catch (ValidationException error) { return BadRequest(error.Message); }
            catch (DbUpdateException) { return Conflict("Не удалось добавить товар."); }
        }

        /// <summary>Сохраняет изменения товара.</summary>
        [Authorize(Roles = "Администратор,Менеджер")]
        [HttpPut("{article}")]
        public async Task<IActionResult> UpdateAsync(string article, ProductEditDto input, CancellationToken ct)
        {
            try
            {
                return await editor.UpdateAsync(article, input, ct) ? NoContent() : NotFound();
            }
            catch (ValidationException error) { return BadRequest(error.Message); }
            catch (DbUpdateException) { return Conflict("Не удалось сохранить товар."); }
        }

        /// <summary>Удаляет товар.</summary>
        [Authorize(Roles = "Администратор,Менеджер")]
        [HttpDelete("{article}")]
        public async Task<IActionResult> DeleteAsync(string article, CancellationToken ct)
        {
            try
            {
                return await editor.DeleteAsync(article, ct) ? NoContent() : NotFound();
            }
            catch (InvalidOperationException error) { return Conflict(error.Message); }
            catch (DbUpdateException) { return Conflict("Не удалось удалить товар."); }
        }
    }
}
