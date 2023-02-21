using ARQ.RabbitMQ.Consumer.Worker.Domain.Interface.Repository;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace ARQ.RabbitMQ.Consumer.Worker.Infrastructure.Data
{
    public class ConnectionFactory : IConnectionFactory
    {
        readonly IConfiguration _configuration;

        public ConnectionFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IDbConnection GetConnection()
        {
            var conn = new OracleConnection(_configuration.GetConnectionString("OracleConnectionString"));

            if (conn.State != ConnectionState.Open)
                conn.Open();

            return conn;
        }
    }
}
