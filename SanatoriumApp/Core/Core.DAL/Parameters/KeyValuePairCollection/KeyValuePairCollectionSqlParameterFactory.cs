using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Core.DAL.Dictionary;

namespace Core.DAL.Parameters.KeyValuePairCollection
{
    public class KeyValuePairCollectionSqlParameterFactory : UDTSqlParameterFactory<KeyValuePair<string, string>>
    {
        protected override string Name => DbDictionary.UDT.KeyValuePairCollection;

        protected override DataColumn[] CreateColumns()
        {
            var columns = new DataColumn[]
            {
                new DataColumn("Key", typeof(string)),
                new DataColumn("Value", typeof(string)),
            };

            return columns;
        }

        protected override void MapDataRow(DataRow row, KeyValuePair<string, string> item)
        {
            row["Key"] = item.Key;
            row["Value"] = item.Value;
        }
    }
}
