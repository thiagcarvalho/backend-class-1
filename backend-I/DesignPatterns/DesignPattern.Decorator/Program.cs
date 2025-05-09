using DesignPatterns.Decorator.Burgers;

namespace DesignPatterns.Decorator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IBurger burger = new MeatBurger();
            Console.WriteLine($"{burger.GetDescription()} - ${burger.GetPrice()}");

            burger = new CheeseDecorator(burger);
            Console.WriteLine($"{burger.GetDescription()} - ${burger.GetPrice()}");

            burger = new BaconDecorator(burger);
            Console.WriteLine($"{burger.GetDescription()} - ${burger.GetPrice()}");

        }
    }
}
