using AutoMapper;
using PetShop.Manager.Application.Contracts.Interfaces.Persistence.Queries.Store;
using PetShop.Manager.Application.Contracts.Models.ViewModels.Store;
using PetShop.Manager.Persistence.DataModels;

namespace PetShop.Manager.Persistence.Query.Store
{
    public class CustomerQueryRepository : ICustomerQueryRepository
    {
        private readonly IMapper _mapper;

        public CustomerQueryRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        public CustomerViewModel? GetByCpf(string cpf)
        {
            var customer = MemoryStorage
                .Customers
                .Values
                .FirstOrDefault(x => x.Cpf == cpf);

            return _mapper.Map<CustomerViewModel?>(customer);
        }
    }
}
