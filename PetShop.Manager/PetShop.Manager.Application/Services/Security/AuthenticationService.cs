using PetShop.Manager.Application.Contracts.Interfaces.Persistence.Queries.Security;
using PetShop.Manager.Application.Contracts.Interfaces.Services.Security;
using PetShop.Manager.Application.Contracts.Models.InputModels.Security;
using PetShop.Manager.Application.Contracts.Models.ViewModels.Security;

namespace PetShop.Manager.Application.Services.Security
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserQueryRepository _userQueryRepository;

        private readonly IRoleQueryRepository _roleQueryRepository;

        public AuthenticationService(
            IUserQueryRepository securityQueryRepository,
            IRoleQueryRepository roleQueryRepository)
        {
            _userQueryRepository = securityQueryRepository;
            _roleQueryRepository = roleQueryRepository;
        }

        public UserViewModel? Authenticate(UserCredentialsInputModel inputModel)
        {
            var user = _userQueryRepository.GetByCredentials(inputModel.Email, inputModel.Password);

            if (user == null)
            {
                return null;
            }

            user.Roles = _roleQueryRepository.GetRolesByUser(user.Id);
            return user;
        }
    }
}
