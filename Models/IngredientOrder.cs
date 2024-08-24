using System;
using System.Collections.Generic;

namespace provide_webapi.Models;

public partial class IngredientOrder
{
    public Guid Id { get; set; }

    public DateTime DateTime { get; set; }

    public int ResponsiblePartyId { get; set; }

    public int SupplierId { get; set; }

    public virtual ICollection<IngredientOrderDelivery> IngredientOrderDeliveries { get; set; } = new List<IngredientOrderDelivery>();

    public virtual ICollection<IngredientOrderDetail> IngredientOrderDetails { get; set; } = new List<IngredientOrderDetail>();

    public virtual Employee ResponsibleParty { get; set; } = null!;

    public virtual Supplier Supplier { get; set; } = null!;
}
