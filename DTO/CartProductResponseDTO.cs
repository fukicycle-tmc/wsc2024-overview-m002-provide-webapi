using System;

namespace provide_webapi.DTO;

public sealed class CartProductResponseDTO
{
    public CartProductResponseDTO(int id, string title, string base64Icon, decimal price, int discountPercentage)
    {
        Id = id;
        Title = title;
        Base64Icon = base64Icon;
        Price = price;
        DiscountPercentage = discountPercentage;
    }

    public int Id { get; }
    public string Title { get; }
    public string Base64Icon { get; }
    public decimal Price { get; }
    public int DiscountPercentage { get; }
}
