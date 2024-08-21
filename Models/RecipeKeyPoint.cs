using System;
using System.Collections.Generic;

namespace provide_webapi.Models;

public partial class RecipeKeyPoint
{
    public int Id { get; set; }

    public int RecipeId { get; set; }

    public string? Comment { get; set; }

    public int Number { get; set; }

    public virtual Recipe Recipe { get; set; } = null!;
}
