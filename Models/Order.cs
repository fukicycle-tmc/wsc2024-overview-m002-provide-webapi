using System;
using System.Collections.Generic;

namespace provide_webapi.Models;

public partial class Order
{
    public Guid Id { get; set; }

    public DateTime DateTime { get; set; }

    public DateTime? EstimateDeliveryDateTime { get; set; }

    public int UserId { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual User User { get; set; } = null!;
}
