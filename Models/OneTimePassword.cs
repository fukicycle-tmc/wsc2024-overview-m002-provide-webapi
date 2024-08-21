using System;
using System.Collections.Generic;

namespace provide_webapi.Models;

public partial class OneTimePassword
{
    public int Id { get; set; }

    public string Code { get; set; } = null!;

    public DateTime ExpiredDateTime { get; set; }

    public int UserId { get; set; }

    public virtual User User { get; set; } = null!;
}
