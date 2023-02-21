using System.Data;

namespace ARQ.RabbitMQ.Consumer.Worker.Domain.Interface.Repository
{
    public interface IConnectionFactory
    {
        IDbConnection GetConnection();
    }
}
