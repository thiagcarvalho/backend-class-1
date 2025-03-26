using PetShop.Manager.Application.Contracts.Models.ViewModels.Security;

namespace PetShop.Manager.Application.Contracts.Interfaces.Persistence.Queries.Security
{
    public interface IRoleQueryRepository
    {
        IEnumerable<RoleViewModel> GetRolesByUser(int userId);
    }
}
