using System;
using System.Net.Mime;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using provide_webapi.DTO;
using provide_webapi.Models;

namespace provide_webapi.Controllers;

[Route("/api/v1/coupons")]
[Authorize]
public sealed class CouponController : ControllerBase
{
    private readonly DB _db;
    public CouponController(DB db)
    {
        _db = db;
    }

    [HttpGet]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType<CouponResponseDTO>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetCoupon()
    {
        var userId = HttpContext.GetUserId();
        var today = DateTime.Today;
        var coupon = _db.Payments.Include(a => a.UserOrder)
            .ToList()
            .FirstOrDefault(a => (a.UserOrder?.UserId == userId ||
                                a.UserId == userId) &&
                                a.CouponId.HasValue &&
                                a.PaymentDateTime.HasValue &&
                                a.PaymentDateTime.Value.Year == today.Year &&
                                a.PaymentDateTime.Value.Month == today.Month);
        if (coupon == default)
        {
            Coupon validCoupon = _db.Coupons.First(a => a.DistributedDate.Year == today.Year && a.DistributedDate.Month == today.Month);
            return Ok(new CouponResponseDTO(
                validCoupon.Id,
                validCoupon.Title,
                validCoupon.Description,
                validCoupon.DiscountPercentage
            ));
        }
        return NotFound("You have already in used.");
    }
}
