using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Manager.Domain
{
    public abstract class Pet : IAnimal{

        public string? Name { get; set; }
        public string Type { get; }

        public int? Age { get; set; }

        protected Pet(string type){
            Type = type;
        }
        public abstract void MakeSound();
    }
}

