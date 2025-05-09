using PetShop.Manager.Application.Contracts.Models.ViewModels.Store;

namespace PetShop.Manager.Application.Contracts.Interfaces.Persistence.Queries.Store
{
    public interface ICustomerQueryRepository
    {
        CustomerViewModel? GetByCpf(string cpf);
    }
}
