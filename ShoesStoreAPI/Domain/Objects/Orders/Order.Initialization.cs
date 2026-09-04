using Domain.ValueObjects.Orders;
using Domain.ValueObjects.Statuses;
using Domain.ValueObjects.Users;

namespace Domain.Objects.Orders
{
    public sealed partial class Order
    {
        private Order(UserId userId, StatusId statusId, OrderCreationDate creationDate, OrderDeliveryDate deliveryDate, OrderCode code)
        {
            OrderId = new(0);
            UserId = userId;
            StatusId = statusId;
            CreationDate = creationDate;
            DeliveryDate = deliveryDate;
            Code = code;
        }

        private Order(long orderId, long userId, long statusId, DateTime creationDate, DateTime deliveryDate, short code)
        {
            OrderId = new(orderId);
            UserId = new(userId);
            StatusId = new(statusId);
            CreationDate = new(creationDate);
            DeliveryDate = new(deliveryDate);
            Code = new(code);
        }

        public static Order Create(UserId userId, StatusId statusId, OrderCreationDate creationDate, OrderDeliveryDate deliveryDate, OrderCode code)
            => new(userId, statusId, creationDate, deliveryDate, code);

        internal static Order Restore(long orderId, long userId, long statusId, DateTime creationDate, DateTime deliveryDate, short code)
            => new(orderId, userId, statusId, creationDate, deliveryDate, code);
    }
}
