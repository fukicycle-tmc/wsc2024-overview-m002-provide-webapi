using System;
using System.Collections.Generic;

namespace provide_webapi.Models;

public partial class SupplierIngredientPrice
{
    public int Id { get; set; }

    public int IngredientId { get; set; }

    public int Price { get; set; }

    public int SupplierId { get; set; }

    public virtual Ingredient Ingredient { get; set; } = null!;

    public virtual Supplier Supplier { get; set; } = null!;
}
