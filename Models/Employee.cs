using System;
using System.Collections.Generic;

namespace provide_webapi.Models;

public partial class Employee
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public int RoleId { get; set; }

    public virtual ICollection<CookingPlan> CookingPlans { get; set; } = new List<CookingPlan>();

    public virtual Role Role { get; set; } = null!;

    public virtual ICollection<Shifting> Shiftings { get; set; } = new List<Shifting>();

    public virtual ICollection<StoreEmployee> StoreEmployees { get; set; } = new List<StoreEmployee>();

    public virtual ICollection<UserDeliveryPlan> UserDeliveryPlans { get; set; } = new List<UserDeliveryPlan>();
}
