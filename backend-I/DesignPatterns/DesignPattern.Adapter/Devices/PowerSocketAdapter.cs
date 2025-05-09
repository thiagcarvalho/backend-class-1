using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPattern.Adapter.Legacy;

namespace DesignPattern.Adapter.Devices
{
    internal class PowerSocketAdapter : IModernPowerSocket
    {
        private readonly OldPowerSocket _oldPowerSocket;

        public PowerSocketAdapter(OldPowerSocket oldPowerSocket)
        {
            _oldPowerSocket = oldPowerSocket;
        }
        public void ProvidePower()
        {
            Console.WriteLine("Adapting old power socket to modern interface...");
            _oldPowerSocket.SupplyPower();
        }
    }
}
