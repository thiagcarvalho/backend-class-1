using PetShop.Manager.Application.Contracts.Models.ViewModels.Security;

namespace PetShop.Manager.Application.Contracts.Interfaces.Persistence.Queries.Security
{
    public interface IUserQueryRepository
    {
        UserViewModel? GetByCredentials(string email, string password);
    }
}
