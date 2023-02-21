namespace ARQ.RabbitMQ.Consumer.Worker.Domain.Model.Configs
{
    public class AppSettingsEnvironmentConfigurations
    {
        public RabbitMqConfig RabbitMqConfig { get; set; }
        public RedisConfig RedisConfig { get; set; }
    }

    public class RabbitMqConfig
    {
        public string Host { get; set; } = string.Empty;
        public ushort Port { get; set; }
        public string User { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string VirtualHost { get; set; } = string.Empty;
        public string Exchange { get; set; } = string.Empty;
        public string ExchangeType { get; set; } = string.Empty;
        public string Queue { get; set; } = string.Empty;
        public string RoutingKey { get; set; } = string.Empty;
    }

    public class RedisConfig
    {
        public string Server { get; set; } = string.Empty;
        public string Port { get; set; } = string.Empty;
        public string User { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string RedisDBNumber { get; set; } = string.Empty;
    }
}
