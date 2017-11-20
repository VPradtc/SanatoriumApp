using System.Data;
using System.Data.SqlClient;
using Core.DAL.Connections;
using Core.DAL.Dictionary;
using Core.DAL.Execution;
using Core.DAL.Extensions;
using Core.DAL.StoredProcedures.Base;
using Core.Domain.Common;
using SanatoriumApp.Domain.MedicalProcedures;

namespace SanatoriumApp.DAL.MedicalProcedures
{
    public class MedicalProceduresGetByPageSqlStoredProcedureQuery : SqlStoredProcedureQuery<KendoGridRequest, MedicalProcedure>
    {
        public MedicalProceduresGetByPageSqlStoredProcedureQuery(IConnectionFactory connectionFactory, IDbCommandInvoker commandInvoker) : base(connectionFactory, commandInvoker)
        {
        }

        public override string Name => DbDictionary.SP.MedicalProcedures.GetByPage;

        public override SqlParameter[] CreateSqlParameters(KendoGridRequest args)
        {
            return new SqlParameter[]
            {
                new SqlParameter("@Take", SqlDbType.Int) { Value = args.Take },
                new SqlParameter("@Skip", SqlDbType.Int) { Value = args.Skip },
            };
        }

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
