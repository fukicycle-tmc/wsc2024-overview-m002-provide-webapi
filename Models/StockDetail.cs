using System;
using System.Collections.Generic;

namespace provide_webapi.Models;

public partial class StockDetail
{
    public int Id { get; set; }

    public int StockId { get; set; }

    public DateOnly DeliveryDate { get; set; }

    public int Amount { get; set; }

    public virtual Stock Stock { get; set; } = null!;
}
