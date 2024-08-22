using System;
using System.Collections.Generic;

namespace provide_webapi.Models;

public partial class Recipe
{
    public int Id { get; set; }

    public int Order { get; set; }

    public int ProductId { get; set; }

    public string? Description { get; set; }

    public int Minutes { get; set; }

    public int RecipeTypeId { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual ICollection<RecipeIngredient> RecipeIngredients { get; set; } = new List<RecipeIngredient>();

    public virtual ICollection<RecipeKeyPoint> RecipeKeyPoints { get; set; } = new List<RecipeKeyPoint>();

    public virtual RecipeType RecipeType { get; set; } = null!;
}
