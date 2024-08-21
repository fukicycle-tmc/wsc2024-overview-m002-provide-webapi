using System;
using System.Collections.Generic;

namespace provide_webapi.Models;

public partial class Ingredient
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int UnitTypeId { get; set; }

    public virtual ICollection<IngredientOrderDetail> IngredientOrderDetails { get; set; } = new List<IngredientOrderDetail>();

    public virtual ICollection<RecipeIngredient> RecipeIngredients { get; set; } = new List<RecipeIngredient>();

    public virtual ICollection<Stock> Stocks { get; set; } = new List<Stock>();

    public virtual ICollection<SupplierIngredientPrice> SupplierIngredientPrices { get; set; } = new List<SupplierIngredientPrice>();

    public virtual UnitType UnitType { get; set; } = null!;

    public virtual ICollection<WarehouseStock> WarehouseStocks { get; set; } = new List<WarehouseStock>();
}
