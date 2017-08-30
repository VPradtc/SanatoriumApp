using System;
using System.Data;
using System.Data.SqlClient;
using Core.Domain.Paging;

namespace Core.DAL.Parameters.Paging
{
    public class PagingParameterCollectionFactory : IParameterCollectionFactory<PagingRequest>
    {
        public SqlParameter[] Create(PagingRequest context)
        {
            return new SqlParameter[]
            {
                new SqlParameter("@PageIndex", SqlDbType.Int){ Value = context.PageIndex },
                new SqlParameter("@PageSize", SqlDbType.Int){ Value = context.PageSize },
                new SqlParameter("@SortDirection", SqlDbType.Int){ Value = (int?)context.SortRequest?.SortDirection },
                new SqlParameter("@SortField", SqlDbType.NVarChar, 256){ Value = context.SortRequest?.SortField },
            };
        }
    }
}
