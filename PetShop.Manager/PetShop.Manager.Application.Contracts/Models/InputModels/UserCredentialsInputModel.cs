using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Manager.Application.Contracts.Models.InputModels
{
    public class UserCredentialsInputModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
