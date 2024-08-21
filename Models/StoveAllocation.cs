using System;
using System.Collections.Generic;

namespace provide_webapi.Models;

public partial class StoveAllocation
{
    public int Id { get; set; }

    public int StoveId { get; set; }

    public int CookingPlanId { get; set; }

    public DateTime StartDateTime { get; set; }

    public DateTime? EndDateTime { get; set; }

    public virtual CookingPlan CookingPlan { get; set; } = null!;

    public virtual Stofe Stove { get; set; } = null!;
}
