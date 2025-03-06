using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace class6
{
    public sealed class Motorcycle : Vehicle{

        public int EngineCapacity { get; set; }
        private bool IsKickstandDown { get; set; }

        public Motorcycle(){
            Type = "Motorcycle";
            IsKickstandDown = false;
        }

        public override void Start()
        {
            if (IsKickstandDown){
                Console.WriteLine("To start a motorcycle you need to put the kickstand down first");
            }else{
                Console.WriteLine("Motorcycle is starting");
            }
        }
        public override void Stop()
        {
            Console.WriteLine("Motorcycle has stopped");
        }

        public void PutKickstandDown(){
            IsKickstandDown = true;
            Console.WriteLine("Kickstand is down");
        }

        public void PutKickstandUp(){
            IsKickstandDown = false;
            Console.WriteLine("Kickstand is up");
        }
    }
}
