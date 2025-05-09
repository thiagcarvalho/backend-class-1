using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Decorator.Burgers
{
    internal class CheeseDecorator : BurgerDecorator
    {
        public CheeseDecorator(IBurger burger) : base(burger) { }
        public override string GetDescription() => base.GetDescription() + ", Cheese";
        public override decimal GetPrice() => base.GetPrice() + 0.75m;
    }

}
