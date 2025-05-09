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

            Console.Write("Enter your age: ");
            int age = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter your salary: ");
            decimal salary = Convert.ToDecimal(Console.ReadLine());

            decimal? discount = GetDiscount(salary);
            var user = new { Name = name, Age = age, Discount = discount };

            if (user.Discount.HasValue){
                Console.WriteLine($"The user {user.Name} has a discount of {user.Discount}");
            }else{
                Console.WriteLine($"The user {user.Name} has no discount");
            }
        }

        static decimal? GetDiscount<T>(T salary) where T : struct
        {
            decimal threshold = 3000;
            decimal salaryDecimal = Convert.ToDecimal(salary);

            if (salaryDecimal < threshold)
            {
                return salaryDecimal * 0.1m;
            }
            return null;
        }
    }
}
