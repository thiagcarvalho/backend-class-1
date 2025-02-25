using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace code_challenge_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int number_1, number_2, total;

            Console.WriteLine("Enter the first number: ");
            number_1 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the second number: ");
            number_2 = Convert.ToInt32(Console.ReadLine());

            total = number_1 + number_2;
            Console.WriteLine("The sum between " + number_1 + " and " + number_2 + " is: " + total);

        }
    }
}
