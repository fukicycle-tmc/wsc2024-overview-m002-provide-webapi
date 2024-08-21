using System;
using System.Collections.Generic;

namespace provide_webapi.Models;

public partial class User
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string Firstname { get; set; } = null!;

    public string Lastname { get; set; } = null!;

    public string Password { get; set; } = null!;

    public DateOnly BirthDate { get; set; }

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    public virtual ICollection<Favorite> Favorites { get; set; } = new List<Favorite>();

    public virtual OneTimePassword? OneTimePassword { get; set; }

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

    public virtual ICollection<UserLock> UserLocks { get; set; } = new List<UserLock>();

    public virtual ICollection<UserLoginAttempt> UserLoginAttempts { get; set; } = new List<UserLoginAttempt>();

    public virtual ICollection<UserOrder> UserOrders { get; set; } = new List<UserOrder>();

    public virtual ICollection<UserPointHistory> UserPointHistories { get; set; } = new List<UserPointHistory>();

    public virtual ICollection<UserToken> UserTokens { get; set; } = new List<UserToken>();
}
