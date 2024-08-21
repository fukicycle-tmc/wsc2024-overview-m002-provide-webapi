using System;

namespace provide_webapi.DTO;

public sealed class ProductResponseDTO
{
    public ProductResponseDTO(int productId, string base64Icon, string title, decimal price, int discountPercentage)
    {
        ProductId = productId;
        Base64Icon = base64Icon;
        Title = title;
        Price = price;
        DiscountPercentage = discountPercentage;
    }
    public int ProductId { get; }
    public string Base64Icon { get; }
    public string Title { get; }
    public decimal Price { get; }
    public int DiscountPercentage { get; }
}
