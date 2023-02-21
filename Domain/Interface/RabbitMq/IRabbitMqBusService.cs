namespace ARQ.RabbitMQ.Consumer.Worker.Domain.Interface.RabbitMq
{
    public interface IRabbitMqBusService
    {
        void Start();
        void Stop();
        void Subscribe(CancellationToken cancellationToken);
    }
}
