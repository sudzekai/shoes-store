using Domain.ValueObjects.Orders;
using Domain.ValueObjects.Statuses;
using Domain.ValueObjects.Users;

namespace Domain.Objects.Orders
{
    /// <summary>
    /// Частичная реализация сущности заказа: свойства и операции изменения.
    /// </summary>
    public sealed partial class Order
    {
        /// <summary>
        /// Идентификатор заказа.
        /// </summary>
        public OrderId OrderId { get; private set; }

        /// <summary>
        /// Идентификатор пользователя, оформившего заказ.
        /// </summary>
        public UserId UserId { get; private set; }

        /// <summary>
        /// Статус заказа.
        /// </summary>
        public StatusId StatusId { get; private set; }

        /// <summary>
        /// Дата создания заказа.
        /// </summary>
        public OrderCreationDate CreationDate { get; private set; }

        /// <summary>
        /// Дата доставки заказа.
        /// </summary>
        public OrderDeliveryDate DeliveryDate { get; private set; }

        /// <summary>
        /// Код заказа.
        /// </summary>
        public OrderCode Code { get; private set; }

        /// <summary>Изменить идентификатор заказа.</summary>
        public void ChangeOrderId(OrderId orderId)
            => OrderId = orderId;

        /// <summary>Изменить идентификатор пользователя.</summary>
        public void ChangeUserId(UserId userId)
            => UserId = userId;

        /// <summary>Изменить статус заказа.</summary>
        public void ChangeStatusId(StatusId statusId)
            => StatusId = statusId;

        /// <summary>Изменить дату создания заказа.</summary>
        public void ChangeCreationDate(OrderCreationDate creationDate)
            => CreationDate = creationDate;

        /// <summary>Изменить дату доставки заказа.</summary>
        public void ChangeDeliveryDate(OrderDeliveryDate deliveryDate)
            => DeliveryDate = deliveryDate;

        /// <summary>Изменить код заказа.</summary>
        public void ChangeCode(OrderCode code)
            => Code = code;
    }
}