using System;
using System.Collections.Generic;

namespace provide_webapi.Models;

public partial class RecipeType
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Recipe> Recipes { get; set; } = new List<Recipe>();
}
