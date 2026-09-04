using Domain.ValueObjects.Orders;
using Domain.ValueObjects.Products;

namespace Domain.Objects.OrderItems
{
    /// <summary>
    /// Частичная реализация позиции заказа: создание и восстановление.
    /// </summary>
    public sealed partial class OrderItem
    {
        /// <summary>
        /// Конструктор для создания новой позиции заказа.
        /// </summary>
        private OrderItem(ProductId productId, OrderId orderId, ProductQuantity quantity)
        {
            ProductId = productId;
            OrderId = orderId;
            Quantity = quantity;
        }

        /// <summary>
        /// Внутренний конструктор для восстановления позиции заказа из хранилища.
        /// </summary>
        private OrderItem(long productId, long orderId, short quantity)
        {
            ProductId = new(productId);
            OrderId = new(orderId);
            Quantity = new(quantity);
        }

        /// <summary>
        /// Создаёт новую позицию заказа.
        /// </summary>
        public static OrderItem Create(ProductId productId, OrderId orderId, ProductQuantity quantity)
            => new(productId, orderId, quantity);

        /// <summary>
        /// Восстанавливает позицию заказа из хранилища.
        /// </summary>
        internal static OrderItem Restore(long productId, long orderId, short quantity)
            => new(productId, orderId, quantity);
    }
}