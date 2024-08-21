using System;
using System.Collections.Generic;

namespace provide_webapi.Models;

public partial class ReviewItem
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int ReviewItemTypeId { get; set; }

    public virtual ICollection<ReviewDetail> ReviewDetails { get; set; } = new List<ReviewDetail>();

    public virtual ReviewItemType ReviewItemType { get; set; } = null!;
}
