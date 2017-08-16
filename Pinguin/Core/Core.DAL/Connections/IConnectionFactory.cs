using System;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Core.DAL.Connections
{
    public interface IConnectionFactory
    {
        SqlConnection CreateConnection();
    }
}
