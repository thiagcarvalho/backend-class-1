using Microsoft.AspNetCore.SignalR.Client;
using System.Threading.Tasks;

namespace Libraries.SignalR.Client;

internal class Program
{
    static async Task Main(string[] args)
    {
        var connection = new HubConnectionBuilder()
            .WithUrl("https://localhost:7233/chathub")
            .WithAutomaticReconnect(reconnectDelays: new[] { TimeSpan.FromSeconds(0), TimeSpan.FromSeconds(2), TimeSpan.FromSeconds(10) })
            .Build();

        await connection.StartAsync();
        Console.WriteLine("Connected to SignalR hub.");

        Console.WriteLine("Write your username (or press Enter for default):");
        var localUser = Console.ReadLine() ?? "DefaultUser";

        connection.On<string, string>("ReceiveMessage", (user, message) =>
        {
            if (!localUser.Equals(user, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine($"<<<<<<<{user}: {message}");
            }
        });

        Console.WriteLine("Enter a message (or type 'exit' to quit):");
        while (true)
        {
            var message = Console.ReadLine();
            if (string.IsNullOrEmpty(message) || message.Equals("exit", StringComparison.OrdinalIgnoreCase))
            {
                break;
            }
            await connection.InvokeAsync("SendMessage", localUser, message);
        }


    }
}
