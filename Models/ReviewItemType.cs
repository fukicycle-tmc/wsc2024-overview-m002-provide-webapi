using System;
using System.Collections.Generic;

namespace provide_webapi.Models;

public partial class ReviewItemType
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<ReviewItem> ReviewItems { get; set; } = new List<ReviewItem>();
}
