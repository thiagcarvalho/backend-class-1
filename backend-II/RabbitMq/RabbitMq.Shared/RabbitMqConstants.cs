namespace RabbitMq.Shared
{
    public class RabbitMqConstants
    {
        public const string DirectExchangeName = "direct_exchange";
        public const string DirectQueueName = "direct_exchange_queue";
        public const string DirectRoutingKey = "direct_exchange_routing_key";
        public const string TopicExchangeName = "topic_exchange";
        public const string TopicQueueName = "topic_exchange_queue";
        public const string TopicRoutingKeyInfo = "messages.Info";
        public const string TopicRoutingKeyWarning = "messages.Warning";
        public const string TopicRoutingKeyError = "messages.Error";
        public const string FanoutExchangeName = "fanout_exchange";
        public const string HeadersExchangeName = "headers_exchange";
        public const string HeadersQueueName = "headers_exchange_queue";
        public const string HeadersKeyName = "headers_exchange_key";
        public const string HeadersKeyValue = "headers_exchange_value";
    }
}
