using System;
using System.Collections.Generic;

namespace provide_webapi.Models;

public partial class UserLock
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public DateTime StartDateTime { get; set; }

    public DateTime EndDateTime { get; set; }

    public virtual User User { get; set; } = null!;
}
