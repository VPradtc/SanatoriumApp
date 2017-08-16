using System.Data.SqlClient;

namespace Core.DAL.Parameters
{
    public interface IParameterCollectionFactory<T>
    {
        SqlParameter[] Create(T context);
    }
}
