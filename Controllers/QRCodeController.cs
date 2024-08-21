using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using provide_webapi.DTO;
using QRCoder;

namespace provide_webapi.Controllers;

[Route("/api/v1/qr-code")]
[Authorize]
public sealed class QRCodeController : ControllerBase
{
    [HttpPost]
    [Produces("application/json")]
    [ProducesResponseType<QRCodeResponseDTO>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public IActionResult Generate(Guid paymentId)
    {
        if (HttpContext.Request.Headers.TryGetValue(AccessTokenAuthenticationOptions.DefaultScheme, out var values))
        {
            string uri = $"http://0.0.0.0:5000/api/v1/payments/{paymentId}?accessToken={values}";
            using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
            using (QRCodeData qRCodeData = qrGenerator.CreateQrCode(uri, QRCodeGenerator.ECCLevel.Q))
            using (PngByteQRCode qrCode = new PngByteQRCode(qRCodeData))
            {
                return Ok(new QRCodeResponseDTO(qrCode.GetGraphic(20), uri));
            }
        }
        return Unauthorized();
    }
}
