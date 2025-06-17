using Bogus;
using Libraries.MessagePack.Models;
using MessagePack;
using Newtonsoft.Json;
using System.Diagnostics;

namespace Libraries.MessagePack;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("MessagePack vs JSON Performance Comparison");
        Console.WriteLine("=========================================");

        const int instanceCount = 1_000_000;

        Console.WriteLine($"Generating {instanceCount:N0} player instances...");
        var stopwatch = Stopwatch.StartNew();

        var faker = new Faker<Pet>()
            .RuleFor(u => u.Name, f => f.Person.FirstName)
            .RuleFor(u => u.Type, f => f.PickRandom("Dog", "Cat", "Parrot"))
            .RuleFor(u => u.Age, f => f.Random.Int(1, 15))
            .RuleFor(u => u.Owner, f => $"{f.Person.FirstName} {f.Person.LastName}");


        var players = faker.Generate(instanceCount);
        stopwatch.Stop();
        Console.WriteLine($"Generation completed in {stopwatch.ElapsedMilliseconds:N0} ms\n");

        Console.WriteLine("1. SERIALIZATION");
        Console.WriteLine("----------------");

        stopwatch.Restart();
        byte[] messagePackData = MessagePackSerializer.Serialize(players);
        stopwatch.Stop();
        Console.WriteLine($"MessagePack serialization: {stopwatch.ElapsedMilliseconds:N0} ms");

        stopwatch.Restart();
        string jsonData = JsonConvert.SerializeObject(players);
        stopwatch.Stop();
        Console.WriteLine($"JSON serialization: {stopwatch.ElapsedMilliseconds:N0} ms");

        Console.WriteLine($"MessagePack size: {messagePackData.Length:N0} bytes");
        Console.WriteLine($"JSON size: {jsonData.Length:N0} bytes");
        Console.WriteLine($"Size reduction: {(1 - (double)messagePackData.Length / jsonData.Length) * 100:N2}%\n");

        Console.WriteLine("2. FILE I/O");
        Console.WriteLine("----------");

        string messagePackFilePath = "players.msgpack";
        string jsonFilePath = "players.json";

        stopwatch.Restart();
        File.WriteAllBytes(messagePackFilePath, messagePackData);
        stopwatch.Stop();
        Console.WriteLine($"MessagePack file write: {stopwatch.ElapsedMilliseconds:N0} ms");

        stopwatch.Restart();
        File.WriteAllText(jsonFilePath, jsonData);
        stopwatch.Stop();
        Console.WriteLine($"JSON file write: {stopwatch.ElapsedMilliseconds:N0} ms");

        stopwatch.Restart();
        byte[] readMessagePackData = File.ReadAllBytes(messagePackFilePath);
        stopwatch.Stop();
        Console.WriteLine($"MessagePack file read: {stopwatch.ElapsedMilliseconds:N0} ms");

        stopwatch.Restart();
        string readJsonData = File.ReadAllText(jsonFilePath);
        stopwatch.Stop();
        Console.WriteLine($"JSON file read: {stopwatch.ElapsedMilliseconds:N0} ms\n");

        Console.WriteLine("3. DESERIALIZATION");
        Console.WriteLine("-----------------");

        stopwatch.Restart();
        var deserializedMessagePackPet = MessagePackSerializer.Deserialize<List<Pet>>(readMessagePackData);
        stopwatch.Stop();
        Console.WriteLine($"MessagePack deserialization: {stopwatch.ElapsedMilliseconds:N0} ms");

        stopwatch.Restart();
        var deserializedJsonPet = JsonConvert.DeserializeObject<List<Pet>>(readJsonData);
        stopwatch.Stop();
        Console.WriteLine($"JSON deserialization: {stopwatch.ElapsedMilliseconds:N0} ms");

        Console.WriteLine($"\nVerification:");
        Console.WriteLine($"MessagePack deserialized count: {deserializedMessagePackPet?.Count ?? 0:N0} players");
        Console.WriteLine($"JSON deserialized count: {deserializedJsonPet?.Count ?? 0:N0} players");

        var messagePackFileInfo = new FileInfo(messagePackFilePath);
        var jsonFileInfo = new FileInfo(jsonFilePath);
        Console.WriteLine($"\nFile size comparison:");
        Console.WriteLine($"MessagePack file: {messagePackFileInfo.Length:N0} bytes");
        Console.WriteLine($"JSON file: {jsonFileInfo.Length:N0} bytes");
        Console.WriteLine($"File size reduction: {(1 - (double)messagePackFileInfo.Length / jsonFileInfo.Length) * 100:N2}%");
    }
}

