using System;
using System.Collections.Generic;

namespace provide_webapi.Models;

public partial class ReviewDetail
{
    public int Id { get; set; }

    public int ReviewItemId { get; set; }

    public string Value { get; set; } = null!;

    public int ReviewId { get; set; }

    public virtual Review Review { get; set; } = null!;

    public virtual ReviewItem ReviewItem { get; set; } = null!;
}
