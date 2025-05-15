using Ju.Mapper;

namespace Mapper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var employee = new Employee
            {
                Id = 1,
                Name = "John Doe",
                Department = "IT",
                BirthDay = new DateTime(1990, 1, 1)
            };
            var customer = JuMapper.Map<Customer>(employee);

            foreach (var prop in typeof(Customer).GetProperties())
            {
                Console.WriteLine($"{prop.Name}: {prop.GetValue(customer)}");
            }
        }
    }
}
