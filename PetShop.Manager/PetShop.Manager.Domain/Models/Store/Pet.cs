using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Manager.Domain.Models.Store
{
    public class Pet : BusinessObjectBase
    {
        public string Name { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;

    }
}
