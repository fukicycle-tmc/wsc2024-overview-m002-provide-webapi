using System;
using System.Diagnostics.CodeAnalysis;
using System.Net.Mime;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using provide_webapi.DTO;
using provide_webapi.Models;

namespace provide_webapi.Controllers;

[Route("/api/v1/payments")]
[Authorize]
public sealed class PaymentController : ControllerBase
{
    private readonly DB _db;
    public PaymentController(DB db)
    {
        _db = db;
    }

    [HttpGet]
    [ProducesResponseType<int>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetPayment()
    {
        var userId = HttpContext.GetUserId();
        Payment? payment = _db.Payments.FirstOrDefault(a => a.UserId == userId && a.PaymentDateTime == null);
        if (payment == default)
        {
            return NotFound("You don't have a payment.");
        }
        return Ok(payment.Id);
    }

    [HttpGet]
    [AllowAnonymous]
    [Route("{paymentId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult CompletePayment(Guid paymentId, [FromQuery] string? accessToken = null)
    {
        if (!_db.Payments.Any(a => a.Id == paymentId && a.PaymentDateTime == null))
        {
            return BadRequest("This payment have already purchased.");
        }
        if (string.IsNullOrEmpty(accessToken))
        {
            return BadRequest("You must include access token.");
        }
        UserToken? userToken = _db.UserTokens.FirstOrDefault(a => a.Token == accessToken && a.ExpiredDate >= DateTime.UtcNow);
        if (userToken == default)
        {
            return BadRequest("Access token is invalid.");
        }
        Payment? payment = _db.Payments.Find(paymentId);
        if (payment == null)
        {
            return NotFound($"No such payment. ID:{paymentId}");
        }
        if (payment.UserId != userToken.UserId)
        {
            return Forbid(AccessTokenAuthenticationOptions.DefaultScheme);
        }
        payment.PaymentDateTime = DateTime.Now;
        _db.SaveChanges();
        return Ok("Complete your payment!");
    }

    [HttpPost]
    [ProducesResponseType<Guid>(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult PostPayment([FromBody] PaymentRequestDTO paymentRequestDTO)
    {
        var userId = HttpContext.GetUserId();
        Cart? cart = _db.Carts.Find(paymentRequestDTO.CartId);
        if (cart == null)
        {
            return BadRequest($"No such cart. ID:{paymentRequestDTO.CartId}");
        }
        if (cart.PaymentId.HasValue)
        {
            return BadRequest($"This payment have already purchased.");
        }
        if ((paymentRequestDTO.Price + paymentRequestDTO.UsedPoints ?? 0) != paymentRequestDTO.PaymentDetails.Sum(a => a.Price * a.Amount))
        {
            return BadRequest($"Price is miss match.");
        }
        Payment payment = new Payment
        {
            Id = Guid.NewGuid(),
            CreateDateTime = DateTime.Now,
            CouponId = paymentRequestDTO.CouponId,
            Price = paymentRequestDTO.Price,
            UsedPoints = paymentRequestDTO.UsedPoints,
            UserId = userId
        };
        _db.Payments.Add(payment);
        foreach (PaymentDetailRequestDTO paymentDetailRequestDTO in paymentRequestDTO.PaymentDetails)
        {
            PaymentDetail paymentDetail = new PaymentDetail
            {
                PaymentId = payment.Id,
                ProductId = paymentDetailRequestDTO.ProductId,
                OriginalPrice = paymentDetailRequestDTO.Price,
                DiscountPrice = paymentDetailRequestDTO.DiscountPrice,
                Amount = paymentDetailRequestDTO.Amount
            };
            _db.PaymentDetails.Add(paymentDetail);
        }
        cart.PaymentId = payment.Id;
        if (paymentRequestDTO.UsedPoints.HasValue && paymentRequestDTO.UsedPoints.Value > 0)
        {
            UserPointHistory userPointHistory = new UserPointHistory
            {
                Point = -paymentRequestDTO.UsedPoints.Value,
                DateTime = DateTime.Now,
                UserId = HttpContext.GetUserId()
            };
            _db.UserPointHistories.Add(userPointHistory);
        }
        try
        {
            _db.SaveChanges();
            return Created("qr-code", payment.Id);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}