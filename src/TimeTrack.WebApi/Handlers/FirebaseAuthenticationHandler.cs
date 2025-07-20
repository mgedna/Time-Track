using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Text.Encodings.Web;
using TimeTrack.Application.Interfaces;

namespace TimeTrack.WebApi.Handlers;

public class FirebaseAuthenticationHandler(
IOptionsMonitor<AuthenticationSchemeOptions> options,
ILoggerFactory logger,
UrlEncoder encoder,
IFirebaseAuthService firebaseAuthService) : AuthenticationHandler<AuthenticationSchemeOptions>(options, logger, encoder)
{
    protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        if (!Request.Headers.ContainsKey("Authorization"))
        {
            return AuthenticateResult.Fail("Missing Authorization Header");
        }

        string token = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");

        var firebaseUid = await firebaseAuthService.ValidateTokenAsync(token);

        if (firebaseUid == null)
        {
            return AuthenticateResult.Fail("Invalid Firebase Token");
        }

        var claims = new[] {
            new Claim(ClaimTypes.NameIdentifier, firebaseUid),
            new Claim(ClaimTypes.Name, firebaseUid)
        };

        var identity = new ClaimsIdentity(claims, Scheme.Name);
        var principal = new ClaimsPrincipal(identity);
        var ticket = new AuthenticationTicket(principal, Scheme.Name);

        return AuthenticateResult.Success(ticket);
    }
}