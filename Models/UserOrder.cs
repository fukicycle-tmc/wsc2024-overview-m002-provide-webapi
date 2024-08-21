using System;
using System.Collections.Generic;

namespace provide_webapi.Models;

public partial class UserOrder
{
    public Guid Id { get; set; }

    public DateTime DateTime { get; set; }

    public DateTime? EstimateDeliveryDateTime { get; set; }

    public int UserId { get; set; }

    public Guid? PaymentId { get; set; }

    public virtual Payment? Payment { get; set; }

    public virtual User User { get; set; } = null!;

    public virtual ICollection<UserDeliveryPlan> UserDeliveryPlans { get; set; } = new List<UserDeliveryPlan>();

    public virtual ICollection<UserOrderDetail> UserOrderDetails { get; set; } = new List<UserOrderDetail>();
}
