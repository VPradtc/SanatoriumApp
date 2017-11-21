using System.Data;
using System.Data.SqlClient;
using Core.DAL.Connections;
using Core.DAL.Dictionary;
using Core.DAL.Execution;
using Core.DAL.Extensions;
using Core.DAL.StoredProcedures.Base;
using SanatoriumApp.Domain.Bookings.ScheduledMedicalProcedures;

namespace SanatoriumApp.DAL.ScheduledMedicalProcedures
{
    public class ScheduledMedicalProceduresGetByIdSqlStoredProcedureQuery : SqlStoredProcedureQuery<int, ScheduledMedicalProcedure>
    {
        public ScheduledMedicalProceduresGetByIdSqlStoredProcedureQuery(IConnectionFactory connectionFactory, IDbCommandInvoker commandInvoker) : base(connectionFactory, commandInvoker)
        {
        }

        public override string Name => DbDictionary.SP.ScheduledMedicalProcedures.GetById;

        public override SqlParameter[] CreateSqlParameters(int args)
        {
            return new SqlParameter[]
            {
                new SqlParameter("@Id", SqlDbType.Int) { Value = args },
            };
        }

        protected override ScheduledMedicalProcedure Map(SqlDataReader reader)
        {
            return new ScheduledMedicalProcedure
            {
                Id = reader.StructField<int>("Id"),
                BookingId = reader.StructField<int>("BookingId"),
                MedicalProcedureId = reader.StructField<int>("MedicalProcedureId"),
                UserId = reader.StructField<int>("UserId"),
                ScheduledDate = reader.UtcDateTimeField("ScheduledDate").Value,

                CreatedBy = reader.StructField<int>("CreatedBy"),
                ModifiedBy = reader.StructField<int>("CreatedBy"),
                CreatedDate = reader.UtcDateTimeField("CreatedDate").Value,
                ModifiedDate = reader.UtcDateTimeField("ModifiedDate").Value,
            };
        }
    }
}
