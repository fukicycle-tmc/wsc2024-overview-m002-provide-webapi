using System;
using System.Collections.Generic;

namespace provide_webapi.Models;

public partial class DeliveryType
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<IngredientDeliveryTracking> IngredientDeliveryTrackings { get; set; } = new List<IngredientDeliveryTracking>();

    public virtual ICollection<UserDeliveryTracking> UserDeliveryTrackings { get; set; } = new List<UserDeliveryTracking>();
}
