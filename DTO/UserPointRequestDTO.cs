using System;

namespace provide_webapi.DTO;

public sealed class UserPointRequestDTO
{
    public UserPointRequestDTO(int point)
    {
        Point = point;
    }
    public int Point { get; }
}
