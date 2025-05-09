using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Decorator.Burgers
{
    internal class MeatBurger : IBurger
    {
        public string GetDescription() => "Meat Burger";
        public decimal GetPrice() => 5.00m;
    }
}
