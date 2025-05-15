using Linq_Class;

namespace classlinq;

public static class Program
{
    public static void Main(string[] args)
    {
        //var customers = CustomerData.Customers;

        //var citizenJamaica = customers.Where(c => c.Country == "Jamaica");

        //var citizenBrunei = customers.Where(c => c.Country == "Brunei Darussalam");

        //var customerwithA = customers.Where(c => c.FirstName.StartsWith("A"));

        //Console.WriteLine("Citizen Jamaica:");
        //citizenJamaica.ToList().ForEach(c => Console.WriteLine($"{c.FirstName} - {c.Country}"));

        //Console.WriteLine("\nCitizen Brunei:");
        //citizenBrunei.ToList().ForEach(c => Console.WriteLine($"{c.FirstName} - {c.Country}"));

        //Console.WriteLine("\nCustomer with A:");
        //customerwithA.ToList().ForEach(c => Console.WriteLine($"{c.FirstName} - {c.Country}"));

        var groupedByCountry = CustomerData
            .Customers
            .OrderBy(c => c.Country)
            .GroupBy(c => c.Country);

        //foreach (var country in groupedByCountry)
        //{
        //    Console.WriteLine($"Country: {country.Key}");
        //    foreach (var customer in country)
        //    {
        //        Console.WriteLine($"{customer.FirstName} {customer.LastName}");
        //    }

        //    Console.WriteLine();
        //}

        Order[] orders = [
            new Order { Id = 1, CustomerId = 500, OrderDescription = "PS5", OrderDate = new DateTime(2024, 12, 25) },
            new Order { Id = 2, CustomerId = 13, OrderDescription = "Iphone 15", OrderDate = new DateTime(2024, 12, 25) },
            new Order { Id = 3, CustomerId = 25, OrderDescription = "TV", OrderDate = new DateTime(DateTime.Now.Year, 04, 13) },
            new Order { Id = 4, CustomerId = 100, OrderDescription = "Magic Cube", OrderDate = new DateTime(DateTime.Now.Year, 01, 25) },
        ];

        var joinResult = CustomerData
            .Customers
            .Join(
                orders,
                customer => customer.ID,
                order => order.CustomerId,
                (customer, order) => new
                {
                    customer.FirstName,
                    customer.LastName,
                    order.OrderDescription,
                    order.OrderDate
                }
            );

        foreach(var item in joinResult)
        {
            Console.WriteLine($"{item.FirstName} {item.LastName} - {item.OrderDescription} - {item.OrderDate.ToShortDateString()}");
        }

    }
}
