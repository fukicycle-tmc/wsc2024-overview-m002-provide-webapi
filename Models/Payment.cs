using System;
using System.Collections.Generic;

namespace provide_webapi.Models;

public partial class Payment
{
    public Guid Id { get; set; }

    public DateTime CreateDateTime { get; set; }

    public DateTime? PaymentDateTime { get; set; }

    public int? Price { get; set; }

    public int? CouponId { get; set; }

    public int? UsedPoints { get; set; }

    public int UserId { get; set; }

    public virtual Cart? Cart { get; set; }

    public virtual Coupon? Coupon { get; set; }

    public virtual ICollection<PaymentDetail> PaymentDetails { get; set; } = new List<PaymentDetail>();

    public virtual User User { get; set; } = null!;

    public virtual UserOrder? UserOrder { get; set; }
}
