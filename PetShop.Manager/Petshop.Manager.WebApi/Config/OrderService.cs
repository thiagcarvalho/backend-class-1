using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetShop.Manager.Domain.Services;

namespace PetShop.Manager.Domain.Services
{
    public class OrderService : IOrderService
    {
        public List<string> GetAllOrders()
        {
            return new List<string> { "01", "02", "13" };
        }
    }
}