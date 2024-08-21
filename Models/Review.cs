using System;
using System.Collections.Generic;

namespace provide_webapi.Models;

public partial class Review
{
    public int Id { get; set; }

    public DateTime DateTime { get; set; }

    public int UserId { get; set; }

    public int ProductId { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual ICollection<ReviewDetail> ReviewDetails { get; set; } = new List<ReviewDetail>();

    public virtual User User { get; set; } = null!;
}
