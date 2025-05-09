using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace class6
{
    public sealed class Car : Vehicle
    {
        public int NumberOfDoors { get; set; }
        private bool TrunkOpen { get; set; }

        public Car(){
            Type = "Car";
            TrunkOpen = false;
            NumberOfDoors = 2;
        }

        public override void Start(){
            if (TrunkOpen){
                Console.WriteLine("You need to close the trunk before start the car");
            } else{
                Console.WriteLine("Car is starting! Vrum");
            }
        }
        public override void Stop()
        {
            Console.WriteLine("Car is stopping now!");
        }

        public void OpenTrunk(){
            TrunkOpen = true;
            Console.WriteLine("Trunk is open");
        }

        public void CloseTrunk(){
            TrunkOpen = false;
            Console.WriteLine("Trunk is closed");
        }
    }
}
