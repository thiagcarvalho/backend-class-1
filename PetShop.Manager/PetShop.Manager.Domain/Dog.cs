using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Manager.Domain
{
    public sealed class Dog : Pet {

        public string? Breed { get; set; }
        public bool IsTrained { get; set; }
        
        public Dog() : base("Dog") { }

        public Dog(string name, int age, string breed, bool isTrained) : base("Dog")
        {
            Name = name;
            Age = age;
            Breed = breed;
            IsTrained = isTrained;
        }

        public override void MakeSound()
        {
            Console.WriteLine("Woof Woof");
        }
    }
}
