using System;
using DesignPattern.Adapter.Devices;
using DesignPattern.Adapter.Legacy;

namespace DesignPattern.Adapter
{
    class Program
    {
        static void Main(string[] args)
        {
            OldPowerSocket oldPowerSocket = new OldPowerSocket();

            IModernPowerSocket adapter = new PowerSocketAdapter(oldPowerSocket);

            ModernDevice modernDevice = new ModernDevice(adapter);

            modernDevice.Charge();
        }
    }
}
