using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using provide_webapi.Models;

namespace provide_webapi.Controllers;

[Route("/api/v1/cart-products")]
[Authorize]
public sealed class CartProductController : ControllerBase
{
    private readonly DB _db;
    public CartProductController(DB db)
    {
        _db = db;
    }

    [HttpPut]
    [Route("{cartProductId}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult PutCartProduct(int cartProductId, int amount)
    {
        if (amount <= 0)
        {
            return BadRequest("Amount does not allowed less equal than 0.");
        }
        CartProduct? cartProduct = _db.CartProducts.Find(cartProductId);
        if (cartProduct == null)
        {
            return NotFound($"No such cart product. ID:{cartProductId}");
        }
        cartProduct.Amount = amount;
        try
        {
            _db.SaveChanges();
            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpDelete]
    [Route("{cartProductId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult DeleteCartProduct(int cartProductId)
    {
        CartProduct? cartProduct = _db.CartProducts.Find(cartProductId);
        if (cartProduct == null)
        {
            return NotFound($"No such cart product. ID:{cartProductId}");
        }
        _db.CartProducts.Remove(cartProduct);
        try
        {
            _db.SaveChanges();
            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}
