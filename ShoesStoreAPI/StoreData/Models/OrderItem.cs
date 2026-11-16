using System;
using System.Collections.Generic;

namespace StoreData.Models;

public partial class OrderItem
{
    public long ProductId { get; set; }

    public long OrderId { get; set; }

    public int Quantity { get; set; }

    public virtual Order Order { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
