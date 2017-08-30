using System.Data;
using System.Data.SqlClient;

namespace Core.DAL.Parameters
{
    public interface IParameterFactory
    {
        SqlParameter Create(string parameterName, object value);
    }
}
