using System;
using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using provide_webapi.DTO;
using provide_webapi.Models;

namespace provide_webapi.Controllers;

[Route("/api/v1/login")]
public sealed class LoginController : ControllerBase
{
    private const int EXPIRED_MINUTE = 60;
    private readonly DB _db;
    public LoginController(DB db)
    {
        _db = db;
    }

    [HttpPost]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType<LoginResponseDTO>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public IActionResult PostLogin([FromBody] LoginRequestDTO loginRequestDTO)
    {
        User? user = _db.Users.FirstOrDefault(a => a.Username == loginRequestDTO.Username && a.Password == loginRequestDTO.Password);
        if (user == default)
        {
            return Unauthorized("Authentication failed.");
        }
        UserToken? userToken = _db.UserTokens.FirstOrDefault(a => a.UserId == user.Id && a.ExpiredDate >= DateTime.UtcNow);
        if (userToken == default)
        {
            //generate new token
            string token = string.Join("", GenerateTokens());
            DateTime expired = DateTime.UtcNow.AddMinutes(EXPIRED_MINUTE);
            UserToken newToken = new UserToken
            {
                Token = token,
                ExpiredDate = expired,
                UserId = user.Id
            };
            _db.UserTokens.Add(newToken);
            _db.SaveChanges();
            return Ok(new LoginResponseDTO(newToken.Token, newToken.ExpiredDate));
        }
        else
        {
            return Ok(new LoginResponseDTO(userToken.Token, userToken.ExpiredDate));
        }
    }

    private IEnumerable<char> GenerateTokens()
    {
        string lower = "abcdefghijklmnopqrstuvwxyz";
        string upper = lower.ToUpper();
        for (int i = 0; i < 64; i++)
        {
            if (Random.Shared.Next() % 2 == 0)
            {
                yield return upper[Random.Shared.Next(0, upper.Length - 1)];
            }
            else
            {
                yield return lower[Random.Shared.Next(0, lower.Length - 1)];
            }
        }
    }
}