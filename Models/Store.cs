using System;
using System.Collections.Generic;

namespace provide_webapi.Models;

public partial class Store
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Address { get; set; } = null!;

    public virtual ICollection<IngredientOrder> IngredientOrders { get; set; } = new List<IngredientOrder>();

    public virtual ICollection<StoreEmployee> StoreEmployees { get; set; } = new List<StoreEmployee>();
}
