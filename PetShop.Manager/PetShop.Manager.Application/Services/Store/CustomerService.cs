using PetShop.Manager.Application.Contracts.Interfaces.Persistence.Commands.Store;
using PetShop.Manager.Application.Contracts.Interfaces.Persistence.Queries.Store;
using PetShop.Manager.Application.Contracts.Interfaces.Services.Store;
using PetShop.Manager.Application.Contracts.Models.InputModels.Store;
using PetShop.Manager.Application.Contracts.Models.ViewModels.Store;

namespace PetShop.Manager.Application.Services.Store
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerCommandRepository _customerCommandRepository;

        private readonly ICustomerQueryRepository _customerQueryRepository;

        public CustomerService(
            ICustomerCommandRepository customerCommandRepository,
            ICustomerQueryRepository customerQueryRepository)
        {
            _customerCommandRepository = customerCommandRepository;
            _customerQueryRepository = customerQueryRepository;
        }

        public void ChangeEmail(string cpf, string email)
        {
            _customerCommandRepository.ChangeEmail(cpf, email);
        }

        public void Save(CustomerInputModel inputModel)
        {
            _customerCommandRepository.Save(inputModel);
        }

        public CustomerViewModel? GetByCpf(string cpf)
        {
            return _customerQueryRepository.GetByCpf(cpf);
        }
    }
}
