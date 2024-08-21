using System;
using System.Collections.Generic;

namespace provide_webapi.Models;

public partial class Cart
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public Guid? PaymentId { get; set; }

    public virtual ICollection<CartProduct> CartProducts { get; set; } = new List<CartProduct>();

    public virtual Payment? Payment { get; set; }

    public virtual User User { get; set; } = null!;
}
