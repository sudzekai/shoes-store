namespace StoreData.Dto
{
    public sealed record OrderItemDto(string Article, string Name, int Quantity, decimal UnitPrice)
    {
        public decimal Total => Quantity * UnitPrice;
    }

    public sealed record OrderDto(
        long Id, string Login, short Code, DateTime CreationDate, DateTime DeliveryDate,
        string Status, List<OrderItemDto> Items)
    {
        public decimal Total => Items.Sum(item => item.Total);
    }

    public sealed record OrderEditDto(long StatusId, DateTime DeliveryDate);
}
