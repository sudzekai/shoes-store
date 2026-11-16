using System;
using System.Collections.Generic;

namespace StoreData.Models;

public partial class Product
{
    public long Id { get; set; }

    public string Article { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public int Quantity { get; set; }

    public short DiscountPercent { get; set; }

    public decimal Price { get; set; }

    public string? PhotoFileName { get; set; }

    public long CategoryId { get; set; }

    public long ManufacturerId { get; set; }

    public long UnitId { get; set; }

    public long SupplierId { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual Manufacturer Manufacturer { get; set; } = null!;

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual Supplier Supplier { get; set; } = null!;

    public virtual Unit Unit { get; set; } = null!;
}
