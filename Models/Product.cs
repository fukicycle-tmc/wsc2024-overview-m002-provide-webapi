using System;
using System.Collections.Generic;

namespace provide_webapi.Models;

public partial class Product
{
    public int Id { get; set; }

    public int CategoryId { get; set; }

    public decimal Price { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public byte[] Icon { get; set; } = null!;

    public virtual ICollection<CartProduct> CartProducts { get; set; } = new List<CartProduct>();

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<CookingPlan> CookingPlans { get; set; } = new List<CookingPlan>();

    public virtual ICollection<Favorite> Favorites { get; set; } = new List<Favorite>();

    public virtual ICollection<PaymentDetail> PaymentDetails { get; set; } = new List<PaymentDetail>();

    public virtual ICollection<Recipe> Recipes { get; set; } = new List<Recipe>();

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

    public virtual ICollection<StoveProduct> StoveProducts { get; set; } = new List<StoveProduct>();

    public virtual ICollection<UserOrderDetail> UserOrderDetails { get; set; } = new List<UserOrderDetail>();
}
