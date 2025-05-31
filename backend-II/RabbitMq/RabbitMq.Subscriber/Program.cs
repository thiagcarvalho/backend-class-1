using RabbitMq.Shared;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Collections;
using System.Text;

namespace RabbitMq.Subscriber
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Rabbit_Mq Subscriber!");

            var factory = new ConnectionFactory();
            using var connection = await factory.CreateConnectionAsync("localhost");
            using var channel = await connection.CreateChannelAsync();

            await channel.ExchangeDeclareAsync(RabbitMqConstants.DirectExchangeName, ExchangeType.Direct);
            await channel.QueueDeclareAsync(RabbitMqConstants.DirectQueueName, durable: true, exclusive: false, autoDelete: false);
            await channel.QueueBindAsync(
                RabbitMqConstants.DirectQueueName, 
                RabbitMqConstants.DirectExchangeName,
                RabbitMqConstants.DirectRoutingKey
            );

            await channel.ExchangeDeclareAsync(RabbitMqConstants.TopicExchangeName, ExchangeType.Topic);
            await channel.QueueDeclareAsync(RabbitMqConstants.TopicQueueName, durable: true, exclusive: false, autoDelete: false);
            await channel.QueueBindAsync(
                RabbitMqConstants.TopicQueueName,
                RabbitMqConstants.TopicExchangeName,
                args[0]
            );

            await channel.ExchangeDeclareAsync(RabbitMqConstants.FanoutExchangeName, ExchangeType.Fanout);
            var fanoutQueue = await channel.QueueDeclareAsync();
            await channel.QueueBindAsync(
                fanoutQueue.QueueName,
                RabbitMqConstants.FanoutExchangeName,
                string.Empty
            );

            await channel.ExchangeDeclareAsync(RabbitMqConstants.HeadersExchangeName, ExchangeType.Headers);
            await channel.QueueDeclareAsync(RabbitMqConstants.HeadersQueueName, durable: true, exclusive: false, autoDelete: false);
            await channel.QueueBindAsync(
                RabbitMqConstants.HeadersQueueName,
                RabbitMqConstants.HeadersExchangeName,
                string.Empty,
                new Dictionary<string, object?>
                {
                    { "x-match", "all" },
                    { RabbitMqConstants.HeadersKeyName, RabbitMqConstants.HeadersKeyValue }
                }
            );

            var consumer = new AsyncEventingBasicConsumer(channel);


            consumer.ReceivedAsync += async (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = System.Text.Encoding.UTF8.GetString(body);
                var headerValue = ea.BasicProperties.Headers?.FirstOrDefault().Value as byte[];
                var decodedHeader = Encoding.UTF8.GetString(headerValue ?? Array.Empty<byte>());
                Console.WriteLine($"{ea.Exchange} - {ea.RoutingKey} -- Headers: {decodedHeader}");
                Console.WriteLine($"Received message: {message}");
                Console.WriteLine("");
                // Acknowledge the message
                await Task.CompletedTask;
            };

            await channel.BasicConsumeAsync(
                queue: RabbitMqConstants.DirectQueueName,
                autoAck: true,
                consumer: consumer
            );

            await channel.BasicConsumeAsync(
                queue: RabbitMqConstants.TopicQueueName,
                autoAck: true,
                consumer: consumer
            );

            await channel.BasicConsumeAsync(
                queue: fanoutQueue.QueueName,
                autoAck: true,
                consumer: consumer
            );

            await channel.BasicConsumeAsync(
                queue: RabbitMqConstants.HeadersQueueName,
                autoAck: true,
                consumer: consumer
            );
            Console.ReadLine();
        }
    }
}
