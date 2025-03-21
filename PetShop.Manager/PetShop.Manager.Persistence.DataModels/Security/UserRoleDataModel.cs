using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Manager.Persistence.DataModels.Security
{
    public class UserRoleDataModel : DataModelBase
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
    }
}
