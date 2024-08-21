using System;
using System.Collections.Generic;

namespace provide_webapi.Models;

public partial class Favorite
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public DateTime DateTime { get; set; }

    public int UserId { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
