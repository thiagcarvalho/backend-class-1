using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace class5
{
    class Program
    {
        static void Main(string[] args)
        {
            Dog dog = new Dog("Spike", 1, "Border Collie", true);
            Cat cat = new Cat("Sagwa", 2, "Siamese", true, "Calm");
            Parrot parrot = new Parrot("Loro", 3, 0.5m, "Green", true);
            List<Pet> pets = new List<Pet> { dog, cat, parrot };


            for(var i = 0; i < pets.Count; i++)
            {
                Console.WriteLine($"Pet: {pets[i].Type} \nName: {pets[i].Name} \nAge: {pets[i].Age}\n");
            }

            if (SellingSettings.EnabbledSellingParrot){
                parrot.SetSold();
            }

        }
    }

    public abstract class Pet{
        
        public string Name { get; set; }
        public string Type { get; set; }
        public int? Age { get; set; }

        public abstract void SetSold();
    }

    public class Dog: Pet{

        public string Breed { get; set; }
        public bool IsTrained { get; set; }

        public Dog(string name, int age, string breed, bool isTrained)   {

            Name = name;
            Type = "Dog";
            Age = age;
            Breed = breed;
            IsTrained = isTrained;
        }

        public override void SetSold()
        {
            Console.WriteLine($"The Dog named {Name} has been sold");
        }
    }

    public class Cat: Pet {

        public string Breed { get; set; }
        public bool IsIndoor { get; set; }
        public string Temperament { get; set; }

        public Cat(string name, int age, string breed, bool isIndoor, string temperament)
        {
            Name = name;
            Type = "Cat";
            Age = age;
            Breed = breed;
            IsIndoor = isIndoor;
            Temperament = temperament;
        }

        public override void SetSold()
        {
            Console.WriteLine($"The Cat named {Name} has been sold");
        }
    }

    sealed class Parrot : Pet
    {

        public decimal Wingspan { get; set; }
        public string Color { get; set; }
        public bool CanSpeak { get; set; }

        public Parrot(string name, int age, decimal wingspan, string color, bool canSpeak)
        {
            Name = name;
            Type = "Parrot";
            Age = age;
            Wingspan = wingspan;
            Color = color;
            CanSpeak = canSpeak;
        }
        public override void SetSold()
        {
            Console.WriteLine($"The Parrot named {Name} has been sold");
        }
    }

    public static class SellingSettings{
        public static bool EnabbledSellingDog { get; set; } = true;
        public static bool EnabbledSellingCat { get; set; } = false;
        public static bool EnabbledSellingParrot { get; set; } = true;
    }

}
