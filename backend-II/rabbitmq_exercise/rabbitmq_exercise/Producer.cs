using RabbitMQ.Client;
using System;
using System.Text;
using System.Threading.Channels;

public class Producer
{
    private readonly IChannel _channel;
    private readonly string _queue;

    public Producer(IChannel channel, string queue)
    {
        _channel = channel;
        _queue = queue;
    }

    public async Task Publish(string message)
    {
        var body = Encoding.UTF8.GetBytes(message);
        await _channel.BasicPublishAsync(exchange: "", routingKey: _queue, body: body);
    }
}