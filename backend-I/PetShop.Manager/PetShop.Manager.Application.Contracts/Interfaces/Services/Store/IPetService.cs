using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetShop.Manager.Application.Contracts.Models.InputModels.Store;
using PetShop.Manager.Application.Contracts.Models.ViewModels.Store;

namespace PetShop.Manager.Application.Contracts.Interfaces.Services.Store
{
    public interface IPetService
    {
        void Save(PetInputModel inputModel);
        PetViewModel? GetById(int Id);
    }
}
