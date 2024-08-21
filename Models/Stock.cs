using System;
using System.Collections.Generic;

namespace provide_webapi.Models;

public partial class Stock
{
    public int Id { get; set; }

    public int IngredientId { get; set; }

    public int Amount { get; set; }

    public int RequiredStockAmount { get; set; }

    public virtual Ingredient Ingredient { get; set; } = null!;
}
