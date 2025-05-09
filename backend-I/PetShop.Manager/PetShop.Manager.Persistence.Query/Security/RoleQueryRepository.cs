using AutoMapper;
using PetShop.Manager.Application.Contracts.Interfaces.Persistence.Queries.Security;
using PetShop.Manager.Application.Contracts.Models.ViewModels.Security;
using PetShop.Manager.Persistence.DataModels;

namespace PetShop.Manager.Persistence.Query.Security
{
    public class RoleQueryRepository : IRoleQueryRepository
    {
        private readonly IMapper _mapper;

        public RoleQueryRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        public IEnumerable<RoleViewModel> GetRolesByUser(int userId)
        {
            var userRoles = MemoryStorage
                .UserRoles
                .Values
                .Where(x => x.UserId == userId)
                .Select(x => x.RoleId) ?? [];

            var roles = MemoryStorage
                .Roles
                .Values
                .Where(x => userRoles.Contains(x.Id));

            return _mapper.Map<IEnumerable<RoleViewModel>>(roles);
        }
    }
}
