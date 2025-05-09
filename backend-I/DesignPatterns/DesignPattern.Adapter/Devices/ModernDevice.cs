using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Adapter.Devices
{
    internal class ModernDevice
    {
        private readonly IModernPowerSocket _powerSocket;

        public ModernDevice(IModernPowerSocket powerSocket)
        {
            _powerSocket = powerSocket;
        }

        public void Charge()
        {
            Console.WriteLine("Charging a modern device...");
            _powerSocket.ProvidePower();
            Console.WriteLine("Modern is charging...");
        }
    }
}
