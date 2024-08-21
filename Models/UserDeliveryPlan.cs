using System;
using System.Collections.Generic;

namespace provide_webapi.Models;

public partial class UserDeliveryPlan
{
    public int Id { get; set; }

    public Guid UserOrderId { get; set; }

    public DateTime? DeliveryDateTime { get; set; }

    public int DriverId { get; set; }

    public virtual Employee Driver { get; set; } = null!;

    public virtual ICollection<UserDeliveryTracking> UserDeliveryTrackings { get; set; } = new List<UserDeliveryTracking>();

    public virtual UserOrder UserOrder { get; set; } = null!;
}
