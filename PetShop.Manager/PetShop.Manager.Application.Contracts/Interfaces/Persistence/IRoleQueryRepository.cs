using PetShop.Manager.Application.Contracts.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Manager.Application.Contracts.Interfaces.Persistence
{
    public interface IRoleQueryRepository
    {
        IEnumerable<RoleViewModel> GetRolesByUser(int userId);
    }
}
