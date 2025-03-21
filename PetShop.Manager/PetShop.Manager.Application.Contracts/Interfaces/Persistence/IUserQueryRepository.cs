using PetShop.Manager.Application.Contracts.Models.ViewModels;

namespace PetShop.Manager.Application.Contracts.Interfaces.Persistence
{
    public interface IUserQueryRepository
    {
        UserViewModel? GetByCredentials(string email, string password);
    }
}
