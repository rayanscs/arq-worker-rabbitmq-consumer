using System.Data;

namespace ARQ.RabbitMQ.Consumer.Worker.Domain.Interface.Repository
{
    public interface IConnectionManager
    {
        IDbConnection DbConnectionFactory();
    }
}
