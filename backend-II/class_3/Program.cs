using System;
using TeamClass;
using AttributeDescription;
using class_3;

class Program
{
    static void Main(string[] args)
    {
        var teamType = typeof(Team);

        var team = new Team();

        object obj = team;
        teamType = obj.GetType();

        Console.WriteLine($"Class: {teamType.Name}");
        Console.WriteLine($"typeof: {teamType.GetType()}");
        Console.WriteLine("=============================");

        foreach (var item in teamType.GetProperties())
        {
            Console.WriteLine($"Property: {item.Name}");
            Console.WriteLine($"Type: {item.PropertyType.Name}");

            foreach (var attribute in item.GetCustomAttributes(true))
            {
                if (attribute is SpecialDescriptionAttribute specialDescription)
                {
                    Console.WriteLine($"Description: {specialDescription.Description}");
                }
            }

            Console.WriteLine("=============================");
        }

    }

    public static void WriteProperties<T>(T instance) where T : IBusinessObject
    {
        foreach (var property in typeof(T).GetProperties())
        {
            Console.WriteLine(property.Name);
            Console.WriteLine(property.PropertyType.Name);
        }
    }
}
