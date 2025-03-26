using PetShop.Manager.Application.Contracts.Models.ViewModels.Security;

namespace PetShop.Manager.Application.Contracts.Interfaces.Services.Security
{
    public interface IJwtService
    {
        string GetToken(UserViewModel user);

        Task<string> GetKeycloakToken(string code, string state);
    }
}
