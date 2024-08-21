using System;
using System.Collections.Generic;

namespace provide_webapi.Models;

public partial class RecipeIngredient
{
    public int Id { get; set; }

    public int RecipeId { get; set; }

    public int IngredientsId { get; set; }

    public decimal Amount { get; set; }

    public virtual Ingredient Ingredients { get; set; } = null!;

    public virtual Recipe Recipe { get; set; } = null!;
}
