namespace ARQ.RabbitMQ.Consumer.Worker.Domain.Interface.Service
{
    public interface IRedisService
    {
        string GetValue(string key);
        void SetValueAsync<T>(string key, T value, TimeSpan? expiryCache);
        void RemoveKey(string key);
    }
}
