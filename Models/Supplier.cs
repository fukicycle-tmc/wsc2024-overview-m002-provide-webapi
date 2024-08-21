using System;
using System.Collections.Generic;

namespace provide_webapi.Models;

public partial class Supplier
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Address { get; set; } = null!;

    public virtual ICollection<SupplierIngredientPrice> SupplierIngredientPrices { get; set; } = new List<SupplierIngredientPrice>();

    public virtual ICollection<Warehouse> Warehouses { get; set; } = new List<Warehouse>();
}
