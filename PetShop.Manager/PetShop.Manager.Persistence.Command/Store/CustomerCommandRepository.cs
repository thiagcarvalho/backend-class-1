using AutoMapper;
using PetShop.Manager.Application.Contracts.Interfaces.Persistence.Commands.Store;
using PetShop.Manager.Application.Contracts.Models.InputModels.Store;
using PetShop.Manager.Persistence.DataModels;
using PetShop.Manager.Persistence.DataModels.Store;
using System.Net;
using System.Net.Mail;

namespace PetShop.Manager.Persistence.Command.Store
{
    public class CustomerCommandRepository : ICustomerCommandRepository
    {
        private readonly IMapper _mapper;

        public CustomerCommandRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        public void ChangeEmail(string cpf, string email)
        {
            var customer = MemoryStorage
                .Customers
                .Values
                .FirstOrDefault(x => x.Cpf == cpf);

            if (customer is null)
            {
                return;
            }

            // Change the email
            customer.Email = email;

            // Notify/validate the new email
            try
            {
                using SmtpClient smtpClient = new();
                smtpClient.Host = "localhost";
                smtpClient.Credentials = new NetworkCredential("admin", "123456");
                smtpClient.Send(
                    new MailMessage(
                        from: new MailAddress("no-reply@petshopmanager.com"),
                        to: new MailAddress(customer.Email))
                    {
                        Body = "Your email was changed, please click <here> to validate this change.",
                    });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void Save(CustomerInputModel inputModel)
        {
            var customerDataModel = _mapper.Map<CustomerDataModel>(inputModel);

            if (inputModel.Id.HasValue)
            {
                MemoryStorage.Customers[inputModel.Id.Value] = customerDataModel;
                return;
            }

            MemoryStorage
                .Customers
                .Add(MemoryStorage.Customers.Count, customerDataModel);
        }
    }
}
