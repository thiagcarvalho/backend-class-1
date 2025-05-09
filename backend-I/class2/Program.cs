using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace class2
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal number1, number2, result;
            int operChoice;
            bool continueLoop = true;
            char choice;
            string userInput;

            while(continueLoop){

                Console.Clear();
                Console.WriteLine("Enter the operation you want to perform: ");
                Console.WriteLine("1. Addition");
                Console.WriteLine("2. Subtraction");
                Console.WriteLine("3. Multiplication");
                Console.WriteLine("4. Division");
                Console.WriteLine("5. Squared");
                Console.WriteLine("6. Exit");
                Console.Write("Enter your choice: ");

                userInput = Console.ReadLine();
                operChoice = Convert.ToInt32(userInput);

                switch(operChoice){
                    case 1:
                        Console.Write("Enter the first number: ");
                        number1 = Convert.ToDecimal(Console.ReadLine());
                        Console.Write("Enter the second number: ");
                        number2 = Convert.ToDecimal(Console.ReadLine());
                        result = number1 + number2;
                        Console.WriteLine("The result is: " + result);
                        break;
                    case 2:
                        Console.Write("Enter the first number: ");
                        number1 = Convert.ToDecimal(Console.ReadLine());
                        Console.Write("Enter the second number: ");
                        number2 = Convert.ToDecimal(Console.ReadLine());
                        result = number1 - number2;
                        Console.WriteLine("The result is: " + result);
                        break;
                    case 3:
                        Console.Write("Enter the first number: ");
                        number1 = Convert.ToDecimal(Console.ReadLine());
                        Console.Write("Enter the second number: ");
                        number2 = Convert.ToDecimal(Console.ReadLine());
                        result = number1 * number2;
                        Console.WriteLine("The result is: " + result);

                        break;
                    case 4:
                        Console.Write("Enter the first number: ");
                        number1 = Convert.ToDecimal(Console.ReadLine());
                        Console.Write("Enter the second number: ");
                        number2 = Convert.ToDecimal(Console.ReadLine());

                        if (number2 == 0){
                            Console.WriteLine("Cannot divide by zero");
                            break;
                        }

                        result = number1 / number2;
                        Console.WriteLine("The result is: " + result);

                        break;

                    case 5:
                        Console.Write("Enter the number: ");
                        number1 = Convert.ToDecimal(Console.ReadLine());
                        result = number1 * number1;
                        Console.WriteLine("The result is: " + result);

                        break;

                    case 6:
                        continueLoop = false;
                        break;

                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }

                Console.Write("Do you want to continue? (y/n): ");
                choice = Convert.ToChar(Console.ReadLine());

                if (choice == 'n' || choice == 'N'){
                    continueLoop = false;
                }

                
            }
        }
    }
}
