using System;
using System.Collections.Generic;

namespace provide_webapi.Models;

public partial class UnitType
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
}
