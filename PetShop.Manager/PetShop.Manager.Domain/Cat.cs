using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Manager.Domain
{
    public sealed class Cat : Pet    {
        public string? Breed { get; set; }
        public bool IsIndoor { get; set; }

        public Cat() : base("Cat"){ }
        public Cat(string name, int age, string breed, bool isIndoor) : base("Cat")
        {
            Name = name;
            Age = age;
            Breed = breed;
            IsIndoor = isIndoor;
        }

        public override void MakeSound(){
            Console.WriteLine("Meow");
        }
    }
}
