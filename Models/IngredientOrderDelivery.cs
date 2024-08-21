using System;
using System.Collections.Generic;

namespace provide_webapi.Models;

public partial class IngredientOrderDelivery
{
    public int Id { get; set; }

    public Guid IngredientOrderId { get; set; }

    public DateTime? DeliveryDateTime { get; set; }

    public int Order { get; set; }

    public virtual ICollection<IngredientDeliveryTracking> IngredientDeliveryTrackings { get; set; } = new List<IngredientDeliveryTracking>();

    public virtual IngredientOrder IngredientOrder { get; set; } = null!;
}
