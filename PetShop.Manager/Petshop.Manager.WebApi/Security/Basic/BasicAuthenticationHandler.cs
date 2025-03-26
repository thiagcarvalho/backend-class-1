using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using PetShop.Manager.WebApi.Extensions;
using System.Security.Claims;
using System.Text.Encodings.Web;

namespace PetShop.Manager.WebApi.Security.Basic
{
    /// <summary>
    /// This class belongs to presentation only because is technology specific (ASP.NET Core)
    /// </summary>
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private readonly Application.Contracts.Interfaces.Services.Security.IAuthenticationService _authenticationService;
        public BasicAuthenticationHandler(
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            Application.Contracts.Interfaces.Services.Security.IAuthenticationService authenticationService) : base(options, logger, encoder)
        {
            _authenticationService = authenticationService;
        }

        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            try
            {
                var user = _authenticationService.Authenticate(Request.GetUserCredentials());

                if (user is not null)
                {
                    var claims = new List<Claim> {
                        new Claim(ClaimTypes.Name, user.Name),
                    };
                    claims.AddRange(user.Roles.Select(x => new Claim(ClaimTypes.Role, x.Role)));

                    var identity = new ClaimsIdentity(claims, Scheme.Name);
                    var principal = new ClaimsPrincipal(identity);
                    var ticket = new AuthenticationTicket(principal, Scheme.Name);

                    return Task.FromResult(AuthenticateResult.Success(ticket));
                }

                return Task.FromResult(AuthenticateResult.Fail("Invalid Username or Password"));
            }
            catch
            {
                return Task.FromResult(AuthenticateResult.Fail("Invalid Authorization Header"));
            }
        }
    }
}
