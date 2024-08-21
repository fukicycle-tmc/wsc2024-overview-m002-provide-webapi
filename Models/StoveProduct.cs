using System;
using System.Collections.Generic;

namespace provide_webapi.Models;

public partial class StoveProduct
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public int StoveId { get; set; }

    public int NumberOfCooksPerShelf { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual Stofe Stove { get; set; } = null!;
}
