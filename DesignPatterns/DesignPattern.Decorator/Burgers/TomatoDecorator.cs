using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Decorator.Burgers
{
    internal class TomatoDecorator : BurgerDecorator
    {
        public TomatoDecorator(IBurger burger) : base(burger) { }

        public override string GetDescription() => base.GetDescription() + ", Tomato";
        public override decimal GetPrice() => base.GetPrice() + 0.50m;
    }
}
