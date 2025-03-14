using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Manager.Domain.Services
{
    public class PetServices : IPetServices {
        public List<string> GetAllPets(){
            return new List<string> { "Dog", "Cat" };
        }
    }
}
