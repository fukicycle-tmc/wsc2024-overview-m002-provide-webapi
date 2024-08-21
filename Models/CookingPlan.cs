using System;
using System.Collections.Generic;

namespace provide_webapi.Models;

public partial class CookingPlan
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public int Amount { get; set; }

    public DateOnly Date { get; set; }

    public TimeOnly? StartTime { get; set; }

    public TimeOnly? EndTime { get; set; }

    public int BakerId { get; set; }

    public virtual Employee Baker { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;

    public virtual ICollection<StoveAllocation> StoveAllocations { get; set; } = new List<StoveAllocation>();
}
