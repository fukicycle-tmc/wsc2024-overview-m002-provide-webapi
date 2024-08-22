using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using provide_webapi.DTO;
using provide_webapi.Models;
using QRCoder;

namespace provide_webapi.Controllers;

[Route("/api/v1/qr-code")]
[Authorize]
public sealed class QRCodeController : ControllerBase
{
    private readonly DB _db;
    private readonly InMemoryPaymentCache _inMemoryPaymentCache;
    public QRCodeController(DB db, InMemoryPaymentCache inMemoryPaymentCache)
    {
        _db = db;
        _inMemoryPaymentCache = inMemoryPaymentCache;
    }

    [HttpPost]
    [Produces("application/json")]
    [ProducesResponseType<QRCodeResponseDTO>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public IActionResult Generate(Guid paymentId)
    {
        Payment? payment = _db.Payments.Find(paymentId);
        if (payment == null)
        {
            return BadRequest($"No such payment. ID:{paymentId}");
        }
        if (payment.PaymentDateTime.HasValue)
        {
            return BadRequest($"This payment has already been completed.");
        }
        if (HttpContext.Request.Headers.TryGetValue("Access-Token", out var values))
        {
            Guid tmpGuid = Guid.NewGuid();
            string uri = $"http://0.0.0.0:5000/api/v1/payments/{paymentId}?accessToken={values}&key={tmpGuid}";
            _inMemoryPaymentCache.Add(paymentId, tmpGuid);
            using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
            using (QRCodeData qRCodeData = qrGenerator.CreateQrCode(uri, QRCodeGenerator.ECCLevel.Q))
            using (PngByteQRCode qrCode = new PngByteQRCode(qRCodeData))
            {
                System.IO.File.WriteAllBytes("qrcode.png", qrCode.GetGraphic(20));
                return Ok(new QRCodeResponseDTO(qrCode.GetGraphic(20), uri));
            }
        }
        return Unauthorized("You have to include 'Access-Token' header.");
    }
}
