using System;
using System.Collections.Generic;

namespace provide_webapi.Models;

public partial class Coupon
{
    public int Id { get; set; }

    public DateOnly DistributedDate { get; set; }

    public DateOnly ExpiredDate { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public int DiscountPercentage { get; set; }

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
}
