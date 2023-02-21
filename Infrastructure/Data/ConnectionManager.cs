using ARQ.RabbitMQ.Consumer.Worker.Domain.Interface.Repository;
using System.Data;

namespace ARQ.RabbitMQ.Consumer.Worker.Infrastructure.Data
{
    public sealed class ConnectionManager : IConnectionManager
    {
        private readonly IDbConnection _connection;

        public ConnectionManager(IDbConnection connection)
        {
            _connection = connection;
        }

        public IDbConnection DbConnectionFactory()
        {
            return _connection;
        }
    }
}
