using System;
using System.Data.SqlClient;

namespace Core.DAL.Extensions
{
    public static class SqlDataReaderExtensions
    {
        public static T Field<T>(this SqlDataReader dataReader, string field)
            where T : class
        {
            var fieldValue = dataReader[field] as T;

            return fieldValue ?? default(T);
        }

        public static T StructField<T>(this SqlDataReader dataReader, string field)
            where T : struct
        {
            var fieldValue = dataReader[field] as Nullable<T>;

            return fieldValue ?? default(T);
        }

        public static DateTime? UtcDateTimeField(this SqlDataReader dataReader, string field)
        {
            var rawFieldValue = dataReader[field] as DateTime?;

            if(rawFieldValue == null)
            {
                return null;
            }

            var fieldValue = DateTime.SpecifyKind(rawFieldValue.Value, DateTimeKind.Utc);

            return fieldValue;
        }

        public static Nullable<T> NullableField<T>(this SqlDataReader dataReader, string field)
            where T : struct
        {
            var fieldValue = dataReader[field] as Nullable<T>;

            return fieldValue ?? null;
        }
    }
}
