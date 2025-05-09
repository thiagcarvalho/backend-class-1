using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace class6
{
    public abstract class Vehicle : IVehicle
    {
        public string Type { get; set; }

        public abstract void Start();
        public abstract void Stop(); 

    }
}
