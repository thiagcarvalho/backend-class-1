using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace class4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter your name: ");
            var name = Console.ReadLine();

            int? age = null;
            Console.Write("Enter your age: ");
            age = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter your salary: ");
            decimal salary = Convert.ToDecimal(Console.ReadLine());

            var user = new { Name = name, Age = age };

            GetDiscount(salary);
        }

        static void GetDiscount<T>(T salary) where T : struct
        {
            double threshold = 3000.0;

            if (Convert.ToDouble(salary) < threshold)
            {
                Console.WriteLine($"The User has {double.Parse(salary.ToString() ?? "0") * 0.1} of discount");
            }
            else
            {
                Console.WriteLine("The user doesn't have discount");
            }
        }
    }
}
