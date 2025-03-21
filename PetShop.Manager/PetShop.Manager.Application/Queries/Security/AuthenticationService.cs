using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetShop.Manager.Application.Contracts.Interfaces;
using PetShop.Manager.Application.Contracts.Models.InputModels;
using PetShop.Manager.Application.Contracts.Models.ViewModels;

namespace PetShop.Manager.Application.Queries.Security
{
    public class AuthenticationService : IAuthenticationService
    {
        public UserViewModel? Authenticate(UserCredentialsInputModel userCredentials)
        {
            throw new NotImplementedException();
        }
    }
}
