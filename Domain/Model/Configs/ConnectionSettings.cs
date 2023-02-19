using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace ARQ.RabbitMQ.Consumer.Worker.Domain.Model.Configs
{
    public class ConnectionSettings
    {
        public IDbConnection OracleConnection => new OracleConnection(OracleConnectionString);
        public string? OracleConnectionString { get; set;}
    }
}
