using System;
using System.Collections.Generic;

namespace provide_webapi.Models;

public partial class UserPointHistory
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int Point { get; set; }

    public DateTime DateTime { get; set; }

    public virtual User User { get; set; } = null!;
}
