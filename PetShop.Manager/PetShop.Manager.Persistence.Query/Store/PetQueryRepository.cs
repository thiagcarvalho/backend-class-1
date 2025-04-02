using AutoMapper;
using PetShop.Manager.Application.Contracts.Interfaces.Persistence.Queries.Store;
using PetShop.Manager.Application.Contracts.Models.ViewModels.Store;
using PetShop.Manager.Persistence.DataModels;

namespace PetShop.Manager.Persistence.Query.Store
{
    public class PetQueryRepository : IPetQueryRepository
    {
        readonly private IMapper _mapper;

        public PetQueryRepository(IMapper mapper)
        {
            _mapper = mapper;
        }
        public PetViewModel? GetById(int Id)
        {
            var pet = MemoryStorage.Pets
                .Values
                .FirstOrDefault(x => x.Id == Id);

            return _mapper.Map<PetViewModel?>(pet);
        }
    }
}
