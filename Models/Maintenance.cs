using System;
using System.Collections.Generic;

namespace provide_webapi.Models;

public partial class Maintenance
{
    public int Id { get; set; }

    public int StoveId { get; set; }

    public DateTime DateTime { get; set; }

    public int OdoHours { get; set; }

    public virtual Stofe Stove { get; set; } = null!;
}
