using System;

namespace provide_webapi.DTO;

public sealed class PaymentDetailRequestDTO
{
    public PaymentDetailRequestDTO(int price, int? discountPrice, int productId)
    {
        Price = price;
        DiscountPrice = discountPrice;
        ProductId = productId;
    }
    public int Price { get; }
    public int? DiscountPrice { get; }
    public int ProductId { get; }
}
