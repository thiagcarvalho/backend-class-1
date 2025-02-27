using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace class3
{
    class Program
    {
        static void Main(string[] args)
        {
            int number1 = 10;
            int number2;

            Console.WriteLine("Before calling the function:");
            Console.WriteLine($"number1: {number1}");

            ExampleFunction(ref number1, out number2);

            Console.WriteLine("After calling the function:");
            Console.WriteLine($"number1: {number1}");
            Console.WriteLine($"number2: {number2}");
        }

        static void ExampleFunction(ref int refParameter, out int outParameter)
        {
            refParameter += 15;
            outParameter = 20;
        }
    }
}
