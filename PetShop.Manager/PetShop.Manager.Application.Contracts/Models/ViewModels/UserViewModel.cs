using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Manager.Application.Contracts.Models.ViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        public required string Email { get; set; }

        public IEnumerable<RoleViewModel> Roles { get; set; } = [];
 
    }
}
