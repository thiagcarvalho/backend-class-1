using AutoMapper;
using PetShop.Manager.Application.Contracts.Interfaces.Persistence.Commands.Store;
using PetShop.Manager.Application.Contracts.Models.InputModels.Store;
using PetShop.Manager.Persistence.DataModels;
using PetShop.Manager.Persistence.DataModels.Store;

namespace PetShop.Manager.Persistence.Command.Store
{
    public class PetCommandRepository : IPetCommandRepository
    {

        private readonly IMapper _mapper;

        public PetCommandRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        public void Save(PetInputModel inputModel)
        {
            var petDataModel = _mapper.Map<PetDataModel>(inputModel);

            if (inputModel.Id.HasValue)
            {
                MemoryStorage.Pets[inputModel.Id.Value] = petDataModel;
                return;
            }

            MemoryStorage
                .Pets
                .Add(MemoryStorage.Customers.Count + 1, petDataModel);

        }
    }
}
