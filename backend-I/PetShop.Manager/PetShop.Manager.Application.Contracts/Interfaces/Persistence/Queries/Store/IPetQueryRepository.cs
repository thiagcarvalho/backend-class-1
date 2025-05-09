using PetShop.Manager.Application.Contracts.Models.ViewModels.Store;

namespace PetShop.Manager.Application.Contracts.Interfaces.Persistence.Queries.Store
{
    public interface IPetQueryRepository
    {
        PetViewModel? GetById(int Id);
    }
}
