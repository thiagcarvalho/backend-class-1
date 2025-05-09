using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Decorator.Burgers
{
    internal abstract class BurgerDecorator : IBurger
    {
        protected IBurger _burger;
        public BurgerDecorator(IBurger burger)
        {
            _burger = burger;
        }
        public virtual string GetDescription() => _burger.GetDescription();
        public virtual decimal GetPrice() => _burger.GetPrice();
    }
}
