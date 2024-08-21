using System;

namespace provide_webapi.DTO;

public sealed class LoginResponseDTO
{
    public LoginResponseDTO(string token, DateTime expired)
    {
        Token = token;
        Expired = expired;
    }
    public string Token { get; }
    public DateTime Expired { get; }
}
