using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Authentication;

namespace provide_webapi;

public sealed class AccessTokenAuthenticationOptions : AuthenticationSchemeOptions
{
    public const string DefaultScheme = "AccessTokenAuthenticationScheme";
    public string TokenHeaderName { get; set; } = "Access-Token";
}