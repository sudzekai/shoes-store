using Domain.ValueObjects.Orders;
using Domain.ValueObjects.Statuses;
using Domain.ValueObjects.Users;

namespace Domain.Objects.Orders
{
    public sealed partial class Order
    {
        public OrderId OrderId { get; private set;  }
        
        public UserId UserId { get; private set; }
        
        public StatusId StatusId { get; private set; }
        
        public OrderCreationDate CreationDate { get; private set; }
        
        public OrderDeliveryDate DeliveryDate { get; private set; }
        
        public OrderCode Code { get; private set; }

        public void ChangeOrderId(OrderId orderId)
            => OrderId = orderId;

        public void ChangeUserId(UserId userId)
            => UserId = userId;

        public void ChangeStatusId(StatusId statusId)
            => StatusId = statusId;

        public void ChangeCreationDate(OrderCreationDate creationDate)
            => CreationDate = creationDate;

        public void ChangeDeliveryDate(OrderDeliveryDate deliveryDate)
            => DeliveryDate = deliveryDate;

        public void ChangeCode(OrderCode code)
            => Code = code;
    }
}
