using Domain.ValueObjects.Orders;
using Domain.ValueObjects.Products;

namespace Domain.Objects.OrderItems
{
    public sealed partial class OrderItem
    {
        private OrderItem(ProductId productId, OrderId orderId, ProductQuantity quantity)
        {
            ProductId = productId;
            OrderId = orderId;
            Quantity = quantity;
        }

        private OrderItem(long productId, long orderId, short quantity)
        {
            ProductId = new(productId);
            OrderId = new(orderId);
            Quantity = new(quantity);
        }

        public static OrderItem Create(ProductId productId, OrderId orderId, ProductQuantity quantity)
            => new(productId, orderId, quantity);

        internal static OrderItem Restore(long productId, long orderId, short quantity)
            => new(productId, orderId, quantity);
    }
}
