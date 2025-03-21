using PetShop.Manager.Application.Contracts.Models.InputModels;
using PetShop.Manager.Application.Contracts.Models.ViewModels;

namespace PetShop.Manager.Application.Contracts.Interfaces
{
    public interface IAuthenticationService
    {
        UserViewModel? Authenticate(UserCredentialsInputModel userCredentials);
    }
}
