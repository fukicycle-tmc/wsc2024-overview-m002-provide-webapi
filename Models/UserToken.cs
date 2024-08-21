using System;
using System.Collections.Generic;

namespace provide_webapi.Models;

public partial class UserToken
{
    public int Id { get; set; }

    public string Token { get; set; } = null!;

    public DateTime ExpiredDate { get; set; }

    public int UserId { get; set; }

    public virtual User User { get; set; } = null!;
}
