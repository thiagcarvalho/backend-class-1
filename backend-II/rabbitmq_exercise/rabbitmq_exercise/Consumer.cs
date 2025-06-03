
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Collections;
using System.Text;
using System.Threading.Channels;

namespace rabbitmq_exercise
{
    public class Consumer
    {
        private readonly IChannel _channel;
        private readonly string _queue;
        private readonly string _broadcastExchange;

        public Consumer(IChannel channel, string queue, string broadcastExchange)
        {
            _channel = channel;
            _queue = queue;
            _broadcastExchange = broadcastExchange;
        }

        public async Task StartAsync()
        {
            var consumer = new AsyncEventingBasicConsumer(_channel);
            consumer.ReceivedAsync += async (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                Console.WriteLine($"[Consumer] Mensagem recebida: {message}");

                var rnd = new Random();
                bool success = rnd.Next(2) == 0;
                string result = success ? "SUCESSO" : "FALHA";

                string broadcastMsg = $"Processamento da mensagem '{message}': {result}";
                var broadcastBody = Encoding.UTF8.GetBytes(broadcastMsg);

                await _channel.BasicPublishAsync(
                    exchange: _broadcastExchange,
                    routingKey: "",
                    body: broadcastBody
                );
            };

            await _channel.BasicConsumeAsync(queue: _queue, autoAck: true, consumer: consumer);
        }
    }
}
