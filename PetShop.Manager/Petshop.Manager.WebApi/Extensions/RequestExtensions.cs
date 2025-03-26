using Microsoft.Extensions.Primitives;
using PetShop.Manager.Application.Contracts.Models.InputModels.Security;
using System.Text;

namespace PetShop.Manager.WebApi.Extensions
{
    public static class RequestExtensions
    {
        public static UserCredentialsInputModel GetUserCredentials(
            this HttpRequest request)
        {
            if (!request.Headers.TryGetValue("Authorization", out StringValues value))
                throw new ApplicationException("The 'Authorization' header is missing");

            var credentialBytes = Convert.FromBase64String(value.ToString().Replace("Basic ", ""));
            var credentials = Encoding.UTF8.GetString(credentialBytes).Split(':');
            var username = credentials[0];
            var password = credentials[1];

            return new UserCredentialsInputModel { Email = username, Password = password };
        }
    }
}
