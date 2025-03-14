using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetShop.Manager.Domain.Services;

namespace PetShop.Manager.Domain.Services
{
    public class CustomerServices : ICustomerService
    {
        public List<string> GetAllCustomers()
        {
            return new List<string> { "Thiago", "Luis" };
        }
    }
}