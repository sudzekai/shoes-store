using Domain.ValueObjects.Orders;
using Domain.ValueObjects.Products;

namespace Domain.Objects.OrderItems
{
    /// <summary>
    /// Частичная реализация позиции заказа: свойства и операции изменения.
    /// </summary>
    public sealed partial class OrderItem
    {
        /// <summary>
        /// Идентификатор товара.
        /// </summary>
        public ProductId ProductId { get; private set; }

        /// <summary>
        /// Идентификатор заказа.
        /// </summary>
        public OrderId OrderId { get; private set; }

        /// <summary>
        /// Количество товара в позиции.
        /// </summary>
        public ProductQuantity Quantity { get; private set; }

        /// <summary>
        /// Изменить идентификатор товара.
        /// </summary>
        public void ChangeProductId(ProductId productId)
            => ProductId = productId;

        /// <summary>
        /// Изменить идентификатор заказа.
        /// </summary>
        public void ChangeOrderId(OrderId orderId)
            => OrderId = orderId;

        /// <summary>
        /// Изменить количество товара в позиции.
        /// </summary>
        public void ChangeProductQuantity(ProductQuantity quantity)
            => Quantity = quantity;
    }
}