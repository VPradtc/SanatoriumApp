using System;
using System.Data;
using Core.DAL.Dictionary;

namespace Core.DAL.Parameters.Collections
{
    public class StringCollectionSqlParameterFactory : UDTSqlParameterFactory<string>
    {
        protected override string Name => DbDictionary.UDT.StringCollection;

        protected override DataColumn[] CreateColumns()
        {
            var columns = new DataColumn[]
            {
                new DataColumn("Value", typeof(string)),
            };

            return columns;
        }

        protected override void MapDataRow(DataRow row, string item)
        {
            row["Value"] = item;
        }
    }
}
