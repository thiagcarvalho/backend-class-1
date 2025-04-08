using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Adapter.Legacy
{
    internal class OldPowerSocket
    {
        public void SupplyPower()
        {
            Console.WriteLine("Supplying power from the old socket.");
        }
    }
}
