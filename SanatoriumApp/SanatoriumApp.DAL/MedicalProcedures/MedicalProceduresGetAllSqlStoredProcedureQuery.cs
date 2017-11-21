using System.Data;
using System.Data.SqlClient;
using Core.DAL.Connections;
using Core.DAL.Dictionary;
using Core.DAL.Execution;
using Core.DAL.Extensions;
using Core.DAL.StoredProcedures.Base;
using SanatoriumApp.Domain.MedicalProcedures;

namespace SanatoriumApp.DAL.MedicalProcedures
{
    public class MedicalProceduresGetAllSqlStoredProcedureQuery : SqlStoredProcedureQuery<MedicalProcedure>
    {
        public MedicalProceduresGetAllSqlStoredProcedureQuery(IConnectionFactory connectionFactory, IDbCommandInvoker commandInvoker) : base(connectionFactory, commandInvoker)
        {
        }

        public override string Name => DbDictionary.SP.MedicalProcedures.GetAll;

        protected override MedicalProcedure Map(SqlDataReader reader)
        {
            return new MedicalProcedure
            {
                Id = reader.StructField<int>("Id"),
                Name = reader.Field<string>("Name"),
                BaseCost = reader.StructField<decimal>("BaseCost"),

                CreatedBy = reader.StructField<int>("CreatedBy"),
                ModifiedBy = reader.StructField<int>("CreatedBy"),
                CreatedDate = reader.UtcDateTimeField("CreatedDate").Value,
                ModifiedDate = reader.UtcDateTimeField("ModifiedDate").Value,
            };
        }
    }
}
