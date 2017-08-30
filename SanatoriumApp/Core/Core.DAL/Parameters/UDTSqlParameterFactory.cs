using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Core.DAL.Parameters
{
    public abstract class UDTSqlParameterFactory<TRow>
    {
        protected abstract DataColumn[] CreateColumns();
        protected abstract void MapDataRow(DataRow row, TRow item);

        protected abstract string Name { get; }

        public SqlParameter Create(string parameterName, ICollection<TRow> collection)
        {
            var table = new DataTable();
            var columns = CreateColumns();

            table.Columns.AddRange(columns);

            foreach (var item in collection)
            {
                var row = table.NewRow();
                MapDataRow(row, item);
                table.Rows.Add(row);
            }

            var result = new SqlParameter(parameterName, table) { TypeName = Name };

            return result;
        }
    }
}
