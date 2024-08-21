using System;
using System.Collections.Generic;

namespace provide_webapi.Models;

public partial class IngredientOrderDetail
{
    public int Id { get; set; }

    public Guid IngredientOrderId { get; set; }

    public int IngredientId { get; set; }

    public int Amount { get; set; }

    public int Price { get; set; }

    public virtual Ingredient Ingredient { get; set; } = null!;

    public virtual IngredientOrder IngredientOrder { get; set; } = null!;
}
