using System;
using System.Collections.Generic;

namespace provide_webapi.Models;

public partial class ShiftingType
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Shifting> Shiftings { get; set; } = new List<Shifting>();
}
