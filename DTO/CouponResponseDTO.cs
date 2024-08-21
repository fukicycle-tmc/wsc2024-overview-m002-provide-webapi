using System;

namespace provide_webapi.DTO;

public sealed class CouponResponseDTO
{
    public CouponResponseDTO(int id, string title, string description, int discountPercentage)
    {
        Id = id;
        Title = title;
        Description = description;
        DiscountPercentage = discountPercentage;
    }

    public int Id { get; }
    public string Title { get; }
    public string Description { get; }
    public int DiscountPercentage { get; }
}
