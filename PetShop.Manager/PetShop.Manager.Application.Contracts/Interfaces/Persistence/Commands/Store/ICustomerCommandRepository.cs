using PetShop.Manager.Application.Contracts.Models.InputModels.Store;

namespace PetShop.Manager.Application.Contracts.Interfaces.Persistence.Commands.Store
{
    public interface ICustomerCommandRepository
    {
        void Save(CustomerInputModel inputModel);

        void ChangeEmail(string cpf, string email);

        void AddPet(string cpf, int petId);
        void RemovePet(string cpf, int petId);
    }
}
