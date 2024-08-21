using System;
using System.Collections.Generic;

namespace provide_webapi.Models;

public partial class Stofe
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int MaintenanceIntervalHour { get; set; }

    public int NumberOfShelves { get; set; }

    public virtual ICollection<Maintenance> Maintenances { get; set; } = new List<Maintenance>();

    public virtual ICollection<StoveAllocation> StoveAllocations { get; set; } = new List<StoveAllocation>();

    public virtual ICollection<StoveProduct> StoveProducts { get; set; } = new List<StoveProduct>();
}
