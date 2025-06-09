using RabbitMq.Shared;
using RabbitMQ.Stream.Client;
using RabbitMQ.Stream.Client.AMQP;
using RabbitMQ.Stream.Client.Reliable;
using System.Net;

namespace RabbitMq.Stream.Producer;

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

        var producer = await RabbitMQ.Stream.Client.Reliable.Producer.Create(new ProducerConfig(streamSystem, RabbitMqConstants.StreamOne));

        int count = 0;
        while (true)
        {
            string tipo = count % 2 == 0 ? "Tico" : "Teco";
            string message = $"{tipo}: Mensagem {count}";
            var data = System.Text.Encoding.UTF8.GetBytes(message);
            await producer.Send(new Message(data));
            Console.WriteLine($"Mensagem enviada: {message}");
            count++;
            await Task.Delay(1000);
        }
    }
}
