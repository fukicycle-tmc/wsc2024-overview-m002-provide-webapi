using System;
using System.Net.Mime;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using provide_webapi.DTO;
using provide_webapi.Models;

namespace provide_webapi.Controllers;

[Route("/api/v1/user-points")]
[Authorize]
public sealed class UserPointController : ControllerBase
{
    private readonly DB _db;
    public UserPointController(DB db)
    {
        _db = db;
    }

    [HttpGet]
    [ProducesResponseType<int>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public IActionResult GetUserPoints()
    {
        var userId = HttpContext.GetUserId();
        var point = _db.UserPointHistories.Where(a => a.UserId == userId).Sum(a => a.Point);
        return Ok(point);
    }

    [HttpPost]
    [ProducesResponseType<int>(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult PostUserPoint([FromBody] UserPointRequestDTO userPointRequestDTO)
    {
        var userId = HttpContext.GetUserId();
        UserPointHistory userPointHistory = new UserPointHistory
        {
            UserId = userId,
            Point = userPointRequestDTO.Point,
            DateTime = DateTime.Now
        };
        _db.UserPointHistories.Add(userPointHistory);
        try
        {
            _db.SaveChanges();
            return Created("user-points", userPointHistory.Id);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}