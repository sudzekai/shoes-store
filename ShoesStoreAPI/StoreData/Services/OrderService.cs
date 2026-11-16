using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;
using StoreData.Data;
using StoreData.Dto;
using StoreData.Models;

namespace StoreData.Services
{
    public sealed class OrderService(ShoesStoreContext db, TimeProvider clock)
    {
        /// <summary>Показывает заказы пользователя или все заказы.</summary>
        public Task<List<OrderDto>> ListAsync(string? login, CancellationToken ct = default)
        {
            var orders = db.Orders.AsNoTracking();
            if (login is not null)
                orders = orders.Where(order => order.User.Login == login);

            return orders.OrderByDescending(order => order.Id)
                .Select(order => new OrderDto(
                    order.Id, order.User.Login, order.Code, order.CreationDate, order.DeliveryDate, order.Status.Name,
                    order.OrderItems.OrderBy(item => item.Product.Article)
                        .Select(item => new OrderItemDto(
                            item.Product.Article, item.Product.Name, item.Quantity,
                            Math.Round(item.Product.Price * (100 - item.Product.DiscountPercent) / 100, 2)))
                        .ToList()))
                .ToListAsync(ct);
        }

        /// <summary>Создаёт заказ на выбранный товар.</summary>
        public async Task<long?> CreateAsync(long userId, long productId, CancellationToken ct = default)
        {
            await using var transaction = await db.Database.BeginTransactionAsync(IsolationLevel.Serializable, ct);
            if (!await db.Products.AnyAsync(product => product.Id == productId, ct))
                return null;

            var usedCodes = await db.Orders.Select(order => order.Code).ToListAsync(ct);
            var freeCodes = Enumerable.Range(100, 900).Select(code => (short)code)
                .Except(usedCodes).ToArray();

            if (freeCodes.Length == 0)
                throw new InvalidOperationException("Свободные коды закончились.");

            var statusId = await db.Statuses.Where(status => status.Name == "Новый")
                .Select(status => status.Id).SingleAsync(ct);
            var today = clock.GetLocalNow().Date;
            var order = new Order
            {
                CreationDate = today,
                DeliveryDate = today.AddDays(7),
                Code = freeCodes[RandomNumberGenerator.GetInt32(freeCodes.Length)],
                UserId = userId,
                StatusId = statusId,
                OrderItems = [new OrderItem { ProductId = productId, Quantity = 1 }]
            };

            db.Orders.Add(order);
            await db.SaveChangesAsync(ct);
            await transaction.CommitAsync(ct);

            return order.Id;
        }

        /// <summary>Показывает доступные статусы.</summary>
        public Task<List<LookupDto>> GetStatusesAsync(CancellationToken ct = default) =>
            db.Statuses.OrderBy(status => status.Id)
                .Select(status => new LookupDto(status.Id, status.Name)).ToListAsync(ct);

        /// <summary>Меняет статус и дату доставки.</summary>
        public async Task<bool> UpdateAsync(long id, OrderEditDto input, CancellationToken ct = default)
        {
            var order = await db.Orders.FindAsync([id], ct);
            if (order is null)
                return false;

            if (input.DeliveryDate == default || !await db.Statuses.AnyAsync(x => x.Id == input.StatusId, ct))
                throw new ValidationException("Проверьте дату доставки и статус.");

            order.DeliveryDate = input.DeliveryDate;
            order.StatusId = input.StatusId;
            await db.SaveChangesAsync(ct);

            return true;
        }
    }
}
