using PetShop.Manager.Application.Contracts.Interfaces.Persistence;
using PetShop.Manager.Application.Contracts.Interfaces.Services.Security;
using PetShop.Manager.Application.Contracts.Models.InputModels;
using PetShop.Manager.Application.Contracts.Models.ViewModels;

namespace PetShop.Manager.Application.Queries.Security
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserQueryRepository _userQueryRepository;
        private readonly IRoleQueryRepository _roleQueryRepository;

        public AuthenticationService(IUserQueryRepository userQueryRepository, IRoleQueryRepository roleQueryRepository){
            _userQueryRepository = userQueryRepository;
            _roleQueryRepository = roleQueryRepository;
        }

        public UserViewModel? Authenticate(UserCredentialsInputModel inputModel){
            
            var user = _userQueryRepository.GetByCredentials(inputModel.Email, inputModel.Password);

            if(user is null){
                return null;
            }

            user.Roles = _roleQueryRepository.GetRolesByUser(user.Id);
            return user;
        }
    }
}
