using System;
using System.Collections.Generic;

namespace provide_webapi.Models;

public partial class UserDeliveryTracking
{
    public Guid Id { get; set; }

    public int DeliveryTypeId { get; set; }

    public DateTime DateTime { get; set; }

    public string? Comment { get; set; }

    public int UserDeliveryPlanId { get; set; }

    public virtual DeliveryType DeliveryType { get; set; } = null!;

    public virtual UserDeliveryPlan UserDeliveryPlan { get; set; } = null!;
}
