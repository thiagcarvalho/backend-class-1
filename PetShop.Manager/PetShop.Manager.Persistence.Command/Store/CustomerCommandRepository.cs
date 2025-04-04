using AutoMapper;
using PetShop.Manager.Application.Contracts.Interfaces.Persistence.Commands.Store;
using PetShop.Manager.Application.Contracts.Models.InputModels.Store;
using PetShop.Manager.Persistence.DataModels;
using PetShop.Manager.Persistence.DataModels.Store;

namespace PetShop.Manager.Persistence.Command.Store
{
    public class CustomerCommandRepository : ICustomerCommandRepository
    {
        private readonly IMapper _mapper;

        public CustomerCommandRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        public void AddPet(string cpf, int petId)
        {
            var customer = MemoryStorage
                .Customers
                .Values
                .FirstOrDefault(x => x.Cpf == cpf) ?? throw new ApplicationException();

            if (customer.Pets.Any(x => x.Id == petId))
            {
                return;
            }

            var pet = MemoryStorage
                .Pets
                .Values
                .FirstOrDefault(x => x.Id == petId);

            if (pet is null)
            {
                return;
            }

            customer.Pets.Add(pet);
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

            customer.Email = email;

        }

        public void RemovePet(string cpf, int petId)
        {
            var customer = MemoryStorage
                .Customers
                .Values
                .FirstOrDefault(x => x.Cpf == cpf) ?? throw new ApplicationException();

            
            if (!customer.Pets.Any(x => x.Id == petId))
            {
                return;
            }

            customer.Pets.Remove(customer.Pets.First(x => x.Id == petId));

        }

        //qual a diferença de UserDataModel para CustomerInputModel
        //como ficaria para validar o valor da chave, teria que comparar com o cpf?
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
                .Add(MemoryStorage.Customers.Count+1, customerDataModel);
        }
    }
}
