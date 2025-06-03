using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace rabbitmq_exercise
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var factory = new ConnectionFactory { HostName = "localhost" };
            using var connection = await factory.CreateConnectionAsync();
            using var channel = await connection.CreateChannelAsync();

            string mainQueue = "intra_process_queue";
            string broadcastExchange = "broadcast_queue";

            await channel.QueueDeclareAsync(mainQueue, durable: false, exclusive: false, autoDelete: true);
            await channel.ExchangeDeclareAsync(broadcastExchange, ExchangeType.Fanout);

            StartBroadcastListener(channel, broadcastExchange);

            var consumer = new Consumer(channel, mainQueue, broadcastExchange);
            var producer = new Producer(channel, mainQueue);

            await consumer.StartAsync();
            Console.WriteLine("Digite as mensagens para enviar (deixe vazio e pressione ENTER para sair):");

            while (true)
            {
                Console.Write("Mensagem: ");
                var message = Console.ReadLine() ?? string.Empty;
                if (string.IsNullOrWhiteSpace(message))
                    break;

                await producer.Publish(message);
            }

            Console.WriteLine("Pressione ENTER para sair");
            Console.ReadLine();
        }

        private static void StartBroadcastListener(IChannel channel, string broadcastExchange)
        {
            var broadcastQueueDeclareOk = channel.QueueDeclareAsync().Result;
            var broadcastQueueName = broadcastQueueDeclareOk.QueueName;

            channel.QueueBindAsync(broadcastQueueName, broadcastExchange, string.Empty);

            var broadcastConsumer = new AsyncEventingBasicConsumer(channel);
            broadcastConsumer.ReceivedAsync += async (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                Console.WriteLine($"[Broadcast] Mensagem recebida: {message}");
                await Task.CompletedTask;
            };

            channel.BasicConsumeAsync(queue: broadcastQueueName, autoAck: true, consumer: broadcastConsumer);

            Console.WriteLine("[Broadcast] Aguardando mensagens de broadcast...");
        }
    }
}
