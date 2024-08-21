using System;
using System.Collections.Generic;

namespace provide_webapi.Models;

public partial class UserOrderDetail
{
    public int Id { get; set; }

    public Guid UserOrderId { get; set; }

    public int ProductId { get; set; }

    public int Amount { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual UserOrder UserOrder { get; set; } = null!;
}
