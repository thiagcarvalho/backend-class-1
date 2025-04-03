using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Decorator.Burgers
{
    internal class BaconDecorator : BurgerDecorator
    {
        public BaconDecorator(IBurger burger) : base(burger) { }
        public override string GetDescription() => base.GetDescription() + ", Bacon";
        public override decimal GetPrice() => base.GetPrice() + 1.50m;

    }
}
