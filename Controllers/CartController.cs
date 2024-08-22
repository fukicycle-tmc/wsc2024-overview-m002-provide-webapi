using System.Net.Mime;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using provide_webapi.DTO;
using provide_webapi.Models;

namespace provide_webapi.Controllers;

[Route("/api/v1/carts")]
[Authorize]
public sealed class CartController : ControllerBase
{
    private readonly DB _db;

    public CartController(DB db)
    {
        _db = db;
    }

    [HttpGet]
    [ProducesResponseType<int>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public IActionResult GetCart()
    {
        var userId = HttpContext.GetUserId();
        Cart? cart = _db.Carts.FirstOrDefault(a => a.UserId == userId && a.PaymentId == null);
        if (cart == default)
        {
            cart = new Cart
            {
                UserId = userId
            };
            _db.Carts.Add(cart);
            _db.SaveChanges();
        }
        return Ok(cart.Id);
    }

    [HttpPost]
    [Route("{cartId}/product")]
    [ProducesResponseType<int>(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult AddProduct(int cartId, [FromBody] CartProductRequestDTO cartProductRequestDTO)
    {
        if (!_db.Carts.Any(a => a.Id == cartId))
        {
            return NotFound($"No such cart. ID:{cartId}");
        }
        if (!_db.Products.Any(a => a.Id == cartProductRequestDTO.ProductId))
        {
            return BadRequest($"No such product. ID:{cartProductRequestDTO.ProductId}");
        }
        if (_db.CartProducts.Any(a => a.CartId == cartId && a.ProductId == cartProductRequestDTO.ProductId))
        {
            return BadRequest("Already added this product. Please use '/api/v1/cart-products/{cartProductId}' endpoints.");
        }
        CartProduct cartProduct = new CartProduct
        {
            CartId = cartId,
            ProductId = cartProductRequestDTO.ProductId,
            Amount = 1,
            DiscountPercentage = cartProductRequestDTO.DiscountPercentage
        };
        _db.CartProducts.Add(cartProduct);
        try
        {
            _db.SaveChanges();
            return Created("cart-products", cartProduct.Id);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpGet]
    [Route("{cartId}/products")]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType<IEnumerable<CartProductResponseDTO>>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public IActionResult GetCartProducts(int cartId)
    {
        if (!_db.Carts.Any(a => a.Id == cartId))
        {
            return NotFound($"No such cart. ID:{cartId}");
        }
        IEnumerable<CartProduct> cartProducts = _db.CartProducts
                                                    .Include(a => a.Product)
                                                    .Include(a => a.Cart)
                                                    .Where(a => a.CartId == cartId);
        return Ok(cartProducts.Select(a =>
            new CartProductResponseDTO(
                a.ProductId,
                a.Product.Title,
                Convert.ToBase64String(a.Product.Icon),
                a.Product.Price,
                a.DiscountPercentage)));
    }

    [HttpGet]
    [Route("{cartId}/products/{productId}")]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType<IEnumerable<CartProductResponseDTO>>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public IActionResult GetCartProduct(int cartId, int productId)
    {
        if (!_db.Carts.Any(a => a.Id == cartId))
        {
            return NotFound($"No such cart. ID:{cartId}");
        }
        CartProduct? cartProduct = _db.CartProducts.Include(a => a.Product)
                                                  .Include(a => a.Cart)
                                                  .FirstOrDefault(a => a.CartId == cartId && a.ProductId == productId);
        if (cartProduct == default)
        {
            return NotFound($"No such product in your cart. CartID:{cartId}, ProductID:{productId}");
        }
        return Ok(new CartProductResponseDTO(
                cartProduct.Id,
                cartProduct.Product.Title,
                Convert.ToBase64String(cartProduct.Product.Icon),
                cartProduct.Product.Price,
                cartProduct.DiscountPercentage));
    }
}