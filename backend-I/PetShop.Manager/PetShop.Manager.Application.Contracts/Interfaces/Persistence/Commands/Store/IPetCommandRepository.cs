using PetShop.Manager.Application.Contracts.Models.InputModels.Store;

namespace PetShop.Manager.Application.Contracts.Interfaces.Persistence.Commands.Store
{
    public interface IPetCommandRepository
    {
        void Save(PetInputModel inputModel);
    }
}
