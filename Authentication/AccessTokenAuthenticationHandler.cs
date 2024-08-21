using System.Security.Claims;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using provide_webapi.Models;

namespace provide_webapi.Authentication;

public sealed class AccessTokenAuthenticationHandler :
    AuthenticationHandler<AccessTokenAuthenticationOptions>
{
    private readonly DB _db;
    public AccessTokenAuthenticationHandler(
        DB db,
        IOptionsMonitor<AccessTokenAuthenticationOptions> options,
        ILoggerFactory logger,
        UrlEncoder encoder) : base(options, logger, encoder)
    {
        _db = db;
    }

    protected override Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        if (!Request.Headers.ContainsKey(Options.TokenHeaderName))
        {
            return Task.FromResult(AuthenticateResult.Fail($"Missing header: {Options.TokenHeaderName}"));
        }
        string token = Request.Headers[Options.TokenHeaderName]!;
        UserToken? userToken = _db.UserTokens.FirstOrDefault(a => a.Token == token && a.ExpiredDate >= DateTime.UtcNow);
        if (userToken == default)
        {
            return Task.FromResult(AuthenticateResult.Fail("Token is expired."));
        }
        var claims = new List<Claim> {
            new Claim(ClaimTypes.Name,userToken.UserId.ToString())
        };
        var claimsIdentity = new ClaimsIdentity
            (claims, AccessTokenAuthenticationOptions.DefaultScheme);
        var claimsPrincipal = new ClaimsPrincipal
            (claimsIdentity);
        return Task.FromResult(AuthenticateResult.Success(new AuthenticationTicket(
            claimsPrincipal,
            AccessTokenAuthenticationOptions.DefaultScheme
        )));
    }
}
