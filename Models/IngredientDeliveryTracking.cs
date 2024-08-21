using System;
using System.Collections.Generic;

namespace provide_webapi.Models;

public partial class IngredientDeliveryTracking
{
    public Guid Id { get; set; }

    public int DeliveryTypeId { get; set; }

    public DateTime DateTime { get; set; }

    public string? Comment { get; set; }

    public int IngredientDeliveryPlanId { get; set; }

    public virtual DeliveryType DeliveryType { get; set; } = null!;

    public virtual IngredientOrderDelivery IngredientDeliveryPlan { get; set; } = null!;
}
