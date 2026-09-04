using Domain.ValueObjects.Orders;
using Domain.ValueObjects.Products;

namespace Domain.Objects.OrderItems
{
    public sealed partial class OrderItem
    {
        public ProductId ProductId { get; private set; }
        
        public OrderId OrderId { get; private set; }

        public ProductQuantity Quantity { get; private set; }
    
        public void ChangeProductId(ProductId productId)
            => ProductId = productId;

        public void ChangeOrderId(OrderId orderId) 
            => OrderId = orderId;

        public void ChangeProductQuantity(ProductQuantity quantity)
            => Quantity = quantity;
    }
}
