using PetShop.Manager.Application.Contracts.Models.InputModels.Store;
using PetShop.Manager.Application.Contracts.Models.ViewModels.Store;

namespace PetShop.Manager.Application.Contracts.Interfaces.Services.Store
{
    public interface ICustomerService
    {
        void Save(CustomerInputModel inputModel);

        void ChangeEmail(string cpf, string email);

        CustomerViewModel? GetByCpf(string cpf);
    }
}
