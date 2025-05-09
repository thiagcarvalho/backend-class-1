using AutoMapper;
using PetShop.Manager.Application.Contracts.Interfaces.Persistence.Queries.Security;
using PetShop.Manager.Application.Contracts.Models.ViewModels.Security;
using PetShop.Manager.Persistence.DataModels;

namespace PetShop.Manager.Persistence.Query.Security
{
    public class UserQueryRepository : IUserQueryRepository
    {
        private readonly IMapper _mapper;

        public UserQueryRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        public UserViewModel? GetByCredentials(string email, string password)
        {
            var user = MemoryStorage
                            .Users
                            .Where(x =>
                                x.Value.Email.ToLower().Equals(email.ToLower())
                                && x.Value.Password.Equals(password))
                            .FirstOrDefault()
                            .Value;

            if (user is null)
            {
                return null;
            }

            return _mapper.Map<UserViewModel>(user);
        }
    }
}
