using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Decorator.Burgers
{
    internal class VeganBurger : IBurger
    {
        public string GetDescription() => "Vegan Burger";
        public decimal GetPrice() => 4.00m;
    }
}
