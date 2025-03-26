using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PetShop.Manager.Application.Contracts.Interfaces.Services.Security;
using PetShop.Manager.Application.Contracts.Models.ViewModels.Security;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PetShop.Manager.Application.Services.Security
{
    public class JwtService : IJwtService
    {
        private readonly IConfiguration _configuration;

        public JwtService(
            IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<string> GetKeycloakToken(string code, string state)
        {
            using var client = new HttpClient();

            var tokenRequest = new FormUrlEncodedContent(
            [
                new KeyValuePair<string, string>("grant_type", "authorization_code"),
                new KeyValuePair<string, string>("code", code),
                new KeyValuePair<string, string>("redirect_uri", _configuration["Authentication:Keycloak:RedirectUri"] ?? throw new ApplicationException()),
                new KeyValuePair<string, string>("client_id", _configuration["Authentication:Keycloak:ClientId"] ?? throw new ApplicationException()),
                new KeyValuePair<string, string>("client_secret", _configuration["Authentication:Keycloak:ClientSecret"] ?? throw new ApplicationException())
            ]);

            var response = await client.PostAsync(
                _configuration["Authentication:Keycloak:TokenEndpoint"] ?? throw new ApplicationException(),
                tokenRequest);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }

            Debug.WriteLine(await response.Content.ReadAsStringAsync());
            throw new ApplicationException("Error requesting the OIDC Token");
        }

        public string GetToken(UserViewModel user)
        {
            var claims = new List<Claim>
            {
                new(ClaimTypes.Name, user.Email),
            };
            claims.AddRange(user.Roles.Select(x => new Claim(ClaimTypes.Role, x.Role)));

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_configuration["JwtConfig:SigningKey"] ?? throw new ApplicationException());
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(1),
                Issuer = _configuration["JwtConfig:Issuer"] ?? throw new ApplicationException(),
                Audience = _configuration["JwtConfig:Audience"] ?? throw new ApplicationException(),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            return tokenString;
        }
    }
}
