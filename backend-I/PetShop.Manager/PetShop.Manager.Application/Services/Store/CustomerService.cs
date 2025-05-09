using PetShop.Manager.Application.Contracts.Interfaces.Infrastructure;
using PetShop.Manager.Application.Contracts.Interfaces.Persistence.Commands.Store;
using PetShop.Manager.Application.Contracts.Interfaces.Persistence.Queries.Store;
using PetShop.Manager.Application.Contracts.Interfaces.Services.Store;
using PetShop.Manager.Application.Contracts.Models.InputModels.Store;
using PetShop.Manager.Application.Contracts.Models.ViewModels.Store;
using PetShop.Manager.Application.Exceptions;

namespace PetShop.Manager.Application.Services.Store
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerCommandRepository _customerCommandRepository;

        private readonly ICustomerQueryRepository _customerQueryRepository;
        private readonly IEmailService _emailService;

        public CustomerService(
            ICustomerCommandRepository customerCommandRepository,
            ICustomerQueryRepository customerQueryRepository,
            IEmailService emailService)
        {
            _customerCommandRepository = customerCommandRepository;
            _customerQueryRepository = customerQueryRepository;
            _emailService = emailService;
        }

        public void ChangeEmail(string cpf, string email)
        {
            //Operação que vai escrever no banco de dados, por isso é o Command.
            _customerCommandRepository.ChangeEmail(cpf, email);
            _emailService.SendEmail(email, "Your email has been changed");
        }

        public void Save(CustomerInputModel inputModel)
        {
            _customerCommandRepository.Save(inputModel);
        }

        public void UpdateCustomer(int id, CustomerInputModel inputModel)
        {
            if (_customerCommandRepository.DoesCustomerExist(id) == false)
            {
                throw new ResourceNotFoundException();
            }
            _customerCommandRepository.UpdateCustomer(id, inputModel);
        }

        public CustomerViewModel? GetByCpf(string cpf)
        {
            return _customerQueryRepository.GetByCpf(cpf);
        }

        public void AddPet(string cpf, int petId)
        {
            _customerCommandRepository.AddPet(cpf, petId);
        }

        public void RemovePet(string cpf, int petId)
        {
            _customerCommandRepository.RemovePet(cpf, petId);
        }
    }
}
