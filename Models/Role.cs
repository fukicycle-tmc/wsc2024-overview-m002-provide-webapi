using System;
using System.Collections.Generic;

namespace provide_webapi.Models;

public partial class Role
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int NumberOfRequired { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
