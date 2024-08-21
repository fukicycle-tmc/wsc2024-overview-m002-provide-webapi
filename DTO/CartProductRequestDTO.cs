using System;

namespace provide_webapi.DTO;

public sealed class CartProductRequestDTO
{
    public CartProductRequestDTO(int productId, int discountPercentage)
    {
        ProductId = productId;
        DiscountPercentage = discountPercentage;
    }
    public int ProductId { get; }
    public int DiscountPercentage { get; }
}
