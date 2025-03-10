using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace class7
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                throw new CustomException("This is an example of custom exception.");
            }
            catch (CustomException ex)
            {
                Console.WriteLine($"Caught custom exception: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Caught general exception: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Finally block was executed.");
            }
        }
    }

    public class CustomException : Exception
    {
        public CustomException(string message) : base(message)
        {
        }
    }
}