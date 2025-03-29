using PetShop.Manager.Application.Contracts.Interfaces.Infrastructure;
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

        public CustomerViewModel? GetByCpf(string cpf)
        {
            return _customerQueryRepository.GetByCpf(cpf);
        }
    }
}
