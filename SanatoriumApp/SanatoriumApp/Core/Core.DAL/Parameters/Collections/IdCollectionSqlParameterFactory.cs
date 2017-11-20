using System;
using System.Data;
using Core.DAL.Dictionary;

namespace Core.DAL.Parameters.Collections
{
    public class IdCollectionSqlParameterFactory : UDTSqlParameterFactory<int>
    {
        protected override string Name => DbDictionary.UDT.IdCollection;

        protected override DataColumn[] CreateColumns()
        {
            var columns = new DataColumn[]
            {
                new DataColumn("Id", typeof(int)),
            };

            return columns;
        }

        protected override void MapDataRow(DataRow row, int item)
        {
            row["Id"] = item;
        }
    }
}
