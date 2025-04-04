using PetShop.Manager.Application.Contracts.Models.InputModels.Store;
using PetShop.Manager.Application.Contracts.Models.ViewModels.Store;

namespace PetShop.Manager.Application.Contracts.Interfaces.Services.Store
{
    public interface ICustomerService
    {
        void Save(CustomerInputModel inputModel);

        void ChangeEmail(string cpf, string email);

        void AddPet(string cpf, int petId);

        void RemovePet(string cpf, int petId);
        CustomerViewModel? GetByCpf(string cpf);
    }
}
