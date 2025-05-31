using RabbitMq.Shared;
using RabbitMQ.Client;

namespace RabbitMq.Publisher
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Rabbit_Mq Publisher!");

            var factory = new ConnectionFactory();
            using var connection = await factory.CreateConnectionAsync("localhost");
            using var channel = await connection.CreateChannelAsync();

            await channel.ExchangeDeclareAsync(RabbitMqConstants.DirectExchangeName, ExchangeType.Direct);
            await channel.ExchangeDeclareAsync(RabbitMqConstants.TopicExchangeName, ExchangeType.Topic);
            await channel.ExchangeDeclareAsync(RabbitMqConstants.FanoutExchangeName, ExchangeType.Fanout);
            await channel.ExchangeDeclareAsync(RabbitMqConstants.HeadersExchangeName, ExchangeType.Headers);

            await channel.BasicPublishAsync(
                exchange: RabbitMqConstants.DirectExchangeName,
                routingKey: RabbitMqConstants.DirectRoutingKey,
                body: System.Text.Encoding.UTF8.GetBytes("Hello, RabbitMQ!")
            );

            Console.WriteLine("Message published successfully!");

            while (true)
            {

                Console.WriteLine($"Press 1 to Direct, 2 to Topic, 3 to Fanout or 4 to Headers");
                var choice = Console.ReadLine();

                Console.WriteLine("Enter a message to publish (or 'exit' to quit):");
                var messsage = Console.ReadLine() ?? string.Empty;

                if (string.IsNullOrEmpty(messsage))
                {
                    Console.WriteLine("Exiting publisher...");
                    break;
                }

                if (choice == "1")
                {
                    await channel.BasicPublishAsync(
                        exchange: RabbitMqConstants.DirectExchangeName,
                        routingKey: RabbitMqConstants.DirectRoutingKey,
                        body: System.Text.Encoding.UTF8.GetBytes(messsage)
                    );
                }
                else if (choice == "2")
                {
                    Console.WriteLine("Enter routing key (e.g., 1 - messages.Info, 2 - messages.Warning, 3 - messages.Error):");
                    var routingKey = Console.ReadLine();

                    if (routingKey == "1")
                    {
                        routingKey = RabbitMqConstants.TopicRoutingKeyInfo;
                    }
                    else if (routingKey == "2")
                    {
                        routingKey = RabbitMqConstants.TopicRoutingKeyWarning;
                    }
                    else if (routingKey == "3")
                    {
                        routingKey = RabbitMqConstants.TopicRoutingKeyError;
                    }
                    else
                    {
                        Console.WriteLine("Invalid routing key. Exiting publisher...");
                        continue;
                    }

                    await channel.BasicPublishAsync(
                        exchange: RabbitMqConstants.TopicExchangeName,
                        routingKey: routingKey,
                        body: System.Text.Encoding.UTF8.GetBytes(messsage)
                    );
                }
                else if (choice == "3")
                {
                    await channel.BasicPublishAsync(
                        exchange: RabbitMqConstants.FanoutExchangeName,
                        routingKey: string.Empty,
                        body: System.Text.Encoding.UTF8.GetBytes(messsage)
                    );
                }
                else if (choice == "4")
                {
                    var headers = new Dictionary<string, object?>
                    {
                        { RabbitMqConstants.HeadersKeyName, RabbitMqConstants.HeadersKeyValue }
                    };
                    var properties = new BasicProperties { 
                        Headers = headers
                    };

                    await channel.BasicPublishAsync(
                        exchange: RabbitMqConstants.HeadersExchangeName,
                        routingKey: string.Empty,
                        mandatory: false,
                        basicProperties: properties,
                        body: System.Text.Encoding.UTF8.GetBytes(messsage)
                    );
                }
                else
                {
                    Console.WriteLine("Invalid choice. Exiting publisher...");
                    continue;
                }

            }
        }
    }
}
