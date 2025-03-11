using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Manager.Domain
{
    public class Customer
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public List<Pet> Pets { get; set; } = new List<Pet>();

        public Customer(string name, string email, string phone){
            Name = name;
            Email = email;
            Phone = phone;
        }

        public void AddPet(Pet pet){
            Pets.Add(pet);
        }

    }
}
