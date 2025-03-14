using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Manager.Domain.Services
{
    public interface IOrderService
    {
        List<string> GetAllOrders();
    }
}
