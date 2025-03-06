using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace class6
{
    class Program
    {
        static void Main(string[] args)
        {
            Car car = new Car();
            Motorcycle motorcycle = new Motorcycle();
            List<Vehicle> vehicles = new List<Vehicle> { car, motorcycle };

            car.OpenTrunk();

            foreach (var vehicle in vehicles){
                vehicle.Start();
            }

        }
    }
}
