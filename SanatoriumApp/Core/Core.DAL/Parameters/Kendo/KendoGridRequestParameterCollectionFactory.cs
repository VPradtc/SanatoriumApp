using System;
using System.Data;
using System.Data.SqlClient;
using Core.Domain.Common;

namespace Core.DAL.Parameters.Kendo
{
    public class KendoGridRequestParameterCollectionFactory : IParameterCollectionFactory<KendoGridRequest>
    {
        public SqlParameter[] Create(KendoGridRequest context)
        {
            return new SqlParameter[]
            {
                new SqlParameter("@Page", SqlDbType.Int){ Value = context.Page },
                new SqlParameter("@PageSize", SqlDbType.Int){ Value = context.PageSize },
                new SqlParameter("@Skip", SqlDbType.Int){ Value = (int?)context.Skip },
                new SqlParameter("@Take", SqlDbType.NVarChar, 256){ Value = context.Take },
            };
        }
    }
}
