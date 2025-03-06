using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace class6
{
    public interface IVehicle
    {
        string Type { get; set; }

        void Start();
        void Stop();
    }
}
