using PetShop.Manager.Application.Contracts.Models.InputModels.Security;
using PetShop.Manager.Application.Contracts.Models.ViewModels.Security;

namespace PetShop.Manager.Application.Contracts.Interfaces.Services.Security
{
    public interface IAuthenticationService
    {
        UserViewModel? Authenticate(UserCredentialsInputModel inputModel);
    }
}
