using System;
using System.Net.Mime;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using provide_webapi.DTO;
using provide_webapi.Models;

namespace provide_webapi.Controllers;

[Route("/api/v1/products")]
[Authorize]
public sealed class ProductController : ControllerBase
{
    private readonly DB _db;
    public ProductController(DB db)
    {
        _db = db;
    }

    [Route("scan")]
    [HttpPost]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType<ProductResponseDTO>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult GetProduct([FromBody] ProductRequestDTO productRequestDTO)
    {
        if (string.IsNullOrEmpty(productRequestDTO.Base64Image))
        {
            return BadRequest("Body is empty value.");
        }
        var products = _db.Products.ToList();
        var product = products[Random.Shared.Next(0, products.Count - 1)];
        return Ok(new ProductResponseDTO(
            product.Id,
            Convert.ToBase64String(product.Icon),
            product.Title,
            product.Price,
            Random.Shared.Next() % 3 == 0 ? Random.Shared.Next(5, 10) : 0
        ));
    }
}