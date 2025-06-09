using RabbitMq.Shared;
using RabbitMQ.Stream.Client;
using RabbitMQ.Stream.Client.Reliable;
using System.Buffers;
using System.Net;
using System.Reflection.Metadata;
namespace RabbitMq.Stream.Consumer;

internal class Program
{
    static async Task Main(string[] args)
    {
        var config = new StreamSystemConfig
        {
            UserName = "guest",
            Password = "guest",
            Endpoints = new[] { IPEndPoint.Parse("127.0.0.1:5552") }
        };

        var streamSystem = await StreamSystem.Create(config);

        if (!await streamSystem.StreamExists(RabbitMqConstants.StreamOne))
        {
            await streamSystem.CreateStream(new StreamSpec(RabbitMqConstants.StreamOne));
            Console.WriteLine("Stream created.");
        }

        var tipo = args[0];

        var consumer = await RabbitMQ.Stream.Client.Reliable.Consumer.Create(new ConsumerConfig(streamSystem, RabbitMqConstants.StreamOne)
        {
            MessageHandler = async (streamname, rawconsumer, context, message) =>
            {
                var text = System.Text.Encoding.UTF8.GetString(message.Data.Contents.ToArray());

                if (text.StartsWith($"{tipo}:"))
                {
                    Console.WriteLine($"[{tipo}] Mensagem consumida: {text}");
                }

                await Task.CompletedTask;
            },
            OffsetSpec = new OffsetTypeNext()
        });

        Console.ReadLine();
    }
}
