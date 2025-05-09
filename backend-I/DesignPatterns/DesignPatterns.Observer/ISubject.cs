using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Observer
{
    internal interface ISubject
    {
        //É crítico alterar o estado do sujeito
        void Attach(IObserver observer);

        void Detach(IObserver observer);

        void Notify();
    }
}
