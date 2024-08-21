using System;
using System.Collections.Generic;

namespace provide_webapi.Models;

public partial class IngredientOrder
{
    public Guid Id { get; set; }

    public DateTime DateTime { get; set; }

    public int StoreId { get; set; }

    public virtual ICollection<IngredientOrderDelivery> IngredientOrderDeliveries { get; set; } = new List<IngredientOrderDelivery>();

    public virtual ICollection<IngredientOrderDetail> IngredientOrderDetails { get; set; } = new List<IngredientOrderDetail>();

    public virtual Store Store { get; set; } = null!;
}
