using Domain.ValueObjects.Orders;
using Domain.ValueObjects.Statuses;
using Domain.ValueObjects.Users;

namespace Domain.Objects.Orders
{
    /// <summary>
    /// Частичная реализация сущности заказа: создание и восстановление.
    /// </summary>
    public sealed partial class Order
    {
        /// <summary>
        /// Конструктор для создания нового заказа (id = 0).
        /// </summary>
        private Order(UserId userId, StatusId statusId, OrderCreationDate creationDate, OrderDeliveryDate deliveryDate, OrderCode code)
        {
            OrderId = new(0);
            UserId = userId;
            StatusId = statusId;
            CreationDate = creationDate;
            DeliveryDate = deliveryDate;
            Code = code;
        }

        /// <summary>
        /// Внутренний конструктор для восстановления заказа из хранилища.
        /// </summary>
        private Order(long orderId, long userId, long statusId, DateTime creationDate, DateTime deliveryDate, short code)
        {
            OrderId = new(orderId);
            UserId = new(userId);
            StatusId = new(statusId);
            CreationDate = new(creationDate);
            DeliveryDate = new(deliveryDate);
            Code = new(code);
        }

        /// <summary>
        /// Создаёт новый заказ.
        /// </summary>
        public static Order Create(UserId userId, StatusId statusId, OrderCreationDate creationDate, OrderDeliveryDate deliveryDate, OrderCode code)
            => new(userId, statusId, creationDate, deliveryDate, code);

        /// <summary>
        /// Восстанавливает заказ из хранилища.
        /// </summary>
        internal static Order Restore(long orderId, long userId, long statusId, DateTime creationDate, DateTime deliveryDate, short code)
            => new(orderId, userId, statusId, creationDate, deliveryDate, code);
    }
}