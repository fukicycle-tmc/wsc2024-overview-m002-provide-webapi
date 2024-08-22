using System;
using System.Collections.Generic;

namespace provide_webapi.Models;

public partial class PaymentDetail
{
    public int Id { get; set; }

    public Guid PaymentId { get; set; }

    public int ProductId { get; set; }

    public int OriginalPrice { get; set; }

    public int? DiscountPrice { get; set; }

    public int Amount { get; set; }

    public virtual Payment Payment { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
