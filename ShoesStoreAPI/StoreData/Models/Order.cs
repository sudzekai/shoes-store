using System;
using System.Collections.Generic;

namespace StoreData.Models;

public partial class Order
{
    public long Id { get; set; }

    public DateTime CreationDate { get; set; }

    public DateTime DeliveryDate { get; set; }

    public short Code { get; set; }

    public long UserId { get; set; }

    public long StatusId { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual Status Status { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
