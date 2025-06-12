using Bogus;
using System;

namespace Libraries.Bogus;

internal class Program
{
    static void Main(string[] args)
    {
        var faker = new Faker<Player>()
            .RuleFor(u => u.Name, f => f.Person.FirstName)
            .RuleFor(u => u.Age, f => f.Random.Int(18, 35))
            .RuleFor(u => u.Nationality, f => f.Address.Country())
            .RuleFor(u => u.Position, f => f.PickRandom(new[] { "Forward", "Midfielder", "Defender", "Goalkeeper" }))
            .RuleFor(u => u.MarketValue, f => f.Finance.Amount(1000000, 100000000, 3));
        

        var players = faker.Generate(22);
        foreach (var player in players)
        {
            Console.WriteLine($"Name: {player.Name} - Age: {player.Age} - Position: {player.Position}  - Nationality: {player.Nationality}");
            Console.WriteLine($"Market Value: {player.MarketValue:C}");
            Console.WriteLine(new string(' ', 50));
        }

    }
}
