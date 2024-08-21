using System;
using System.Collections.Generic;

namespace provide_webapi.Models;

public partial class UserLoginAttempt
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public DateTime DateTime { get; set; }

    public bool IsSuccess { get; set; }

    public virtual User User { get; set; } = null!;
}
