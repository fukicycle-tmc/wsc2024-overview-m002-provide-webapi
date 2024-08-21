using System;

namespace provide_webapi.DTO;

public sealed class PaymentRequestDTO
{
    public PaymentRequestDTO(int cartId, int? couponId, int? usedPoints, int price, IEnumerable<PaymentDetailRequestDTO> paymentDetails)
    {
        CartId = cartId;
        CouponId = couponId;
        UsedPoints = usedPoints;
        Price = price;
        PaymentDetails = paymentDetails;
    }
    public int CartId { get; }
    public int? CouponId { get; }
    public int? UsedPoints { get; }
    public int Price { get; }
    public IEnumerable<PaymentDetailRequestDTO> PaymentDetails { get; }
}
