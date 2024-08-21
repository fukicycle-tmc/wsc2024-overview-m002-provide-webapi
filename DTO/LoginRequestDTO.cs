using System;

namespace provide_webapi.DTO;

public sealed class LoginRequestDTO
{
    public LoginRequestDTO(string username, string password)
    {
        Username = username;
        Password = password;
    }
    public string Username { get; }
    public string Password { get; }
}
