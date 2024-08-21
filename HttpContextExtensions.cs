using System;
using System.Security.Claims;

namespace provide_webapi;

public static class HttpContextExtensions
{
    public static int GetUserId(this HttpContext httpContext)
    {
        var userId = httpContext.User.Claims.FirstOrDefault(a => a.Type == ClaimTypes.Name);
        if (userId == default)
        {
            throw new Exception("Invalid context.");
        }
        return Convert.ToInt32(userId.Value);
    }
}
