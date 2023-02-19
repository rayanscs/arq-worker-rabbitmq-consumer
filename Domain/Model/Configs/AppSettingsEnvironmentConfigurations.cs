namespace ARQ.RabbitMQ.Consumer.Worker.Domain.Model.Configs
{
    internal class AppSettingsEnvironmentConfigurations
    {
        public RabbitMqConfig RabbitMqConfig { get; set; }
        public RedisConfig RedisConfig { get; set; }
    }

    class RabbitMqConfig
    {
        public string Host { get; set; } = string.Empty;
        public string Port { get; set; } = string.Empty;
        public string User { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string VirtualHost { get; set; } = string.Empty;
        public string Queue { get; set; } = string.Empty;
        public string MyProperty { get; set; } = string.Empty;
    }

    class RedisConfig
    {
        public string Server { get; set; } = string.Empty;
        public string Port { get; set; } = string.Empty;
        public string User { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
