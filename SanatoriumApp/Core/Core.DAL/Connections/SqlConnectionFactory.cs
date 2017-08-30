using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Core.DAL.Connections
{
    public class SqlConnectionFactory : IConnectionFactory
    {
        private const string ConnectionStringName = "DBConnectionString";
        private readonly string _connectionString;

        public SqlConnectionFactory()
        {
            _connectionString = ConfigurationManager.ConnectionStrings[ConnectionStringName].ConnectionString;
        }

        public SqlConnection CreateConnection()
        {
            var connection = new SqlConnection(_connectionString);

            return connection;
        }
    }
}
