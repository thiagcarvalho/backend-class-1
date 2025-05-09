using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetShop.Manager.Application.Contracts.Interfaces.Persistence.Commands.Store;
using PetShop.Manager.Application.Contracts.Interfaces.Persistence.Queries.Store;
using PetShop.Manager.Application.Contracts.Interfaces.Services.Store;
using PetShop.Manager.Application.Contracts.Models.InputModels.Store;
using PetShop.Manager.Application.Contracts.Models.ViewModels.Store;

namespace PetShop.Manager.Application.Services.Store
{
    public class PetService : IPetService
    {
        private readonly IPetCommandRepository _petCommandRepository;
        private readonly IPetQueryRepository _petQueryRepository;

        public PetService(
            IPetCommandRepository petCommandRepository,
            IPetQueryRepository petQueryRepository) 
        {
            _petCommandRepository = petCommandRepository;
            _petQueryRepository = petQueryRepository;
        }


        public PetViewModel? GetById(int Id)
        {
            return _petQueryRepository.GetById(Id);
        }

        public void Save(PetInputModel inputModel)
        {
            _petCommandRepository.Save(inputModel);
        }
    }
}
