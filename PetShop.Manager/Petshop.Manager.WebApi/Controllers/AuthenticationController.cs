using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetShop.Manager.Application.Contracts.Interfaces.Services.Security;
using PetShop.Manager.Application.Contracts.Models.InputModels.Security;
using PetShop.Manager.WebApi.Config;
using PetShop.Manager.WebApi.Extensions;
using System.Security.Claims;

namespace PetShop.Manager.WebApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        private readonly IJwtService _jwtService;

        private readonly HttpClient _httpClient;

        public AuthenticationController(
            IAuthenticationService authenticationService,
            IJwtService jwtService,
            HttpClient httpClient,
            IConfiguration configuration)
        {
            _authenticationService = authenticationService;
            _jwtService = jwtService;
            _httpClient = httpClient;
        }

        [HttpGet("basic")]
        public IActionResult Basic()
        {
            var user = _authenticationService.Authenticate(Request.GetUserCredentials());

            if (user == null)
            {
                return Unauthorized();
            }

            return Ok(user);
        }

        [HttpPost("login")]
        public IActionResult Login(
            [FromBody] UserCredentialsInputModel inputModel)
        {
            var user = _authenticationService.Authenticate(inputModel);

            if (user == null)
            {
                return Unauthorized();
            }

            return Ok(new { access_token = _jwtService.GetToken(user) });
        }

        [HttpGet("login/oidc")]
        public IActionResult LoginOidc()
        {
            return Redirect(
                "http://localhost:8080/realms/petshop-manager/protocol/openid-connect/auth?client_id=petshop-manager-client&redirect_uri=https://localhost:7227/api/v1/authentication/login/oidc/redirect&response_type=code&state=abcde&scope=openid");
        }

        [HttpGet("login/oidc/redirect")]
        public async Task<IActionResult> LoginOidcRedirect(string code, string state)
        {
            var token = await _jwtService.GetKeycloakToken(code, state);
            return Ok(token);
        }

        [HttpGet("login/oauth")]
        public IActionResult LoginOauth()
        {
            if (!User?.Identity?.IsAuthenticated ?? true)
            {
                return Challenge("OAuthProvider");
            }

            return Redirect("/welcome");
        }

        [HttpGet("login/oauth/redirect")]
        public IActionResult LoginOauthRedirect()
        {
            return Ok();
        }

        [Authorize(AuthenticationSchemes = Constants.AuthSchemes)]
        [HttpGet("/welcome")]
        public IActionResult Welcome()
        {
            return Ok(new
            {
                Message = $"Welcome, {User.FindFirst(ClaimTypes.Name)!.Value}",
                HomeUri = "https://petshopmanager.com/home"
            });
        }
    }
}
