using System;
using System.Collections.Generic;

namespace provide_webapi.Models;

public partial class StoreEmployee
{
    public int Id { get; set; }

    public int StoreId { get; set; }

    public int EmployeeId { get; set; }

    public DateOnly HireDate { get; set; }

    public virtual Employee Employee { get; set; } = null!;

    public virtual Store Store { get; set; } = null!;
}
