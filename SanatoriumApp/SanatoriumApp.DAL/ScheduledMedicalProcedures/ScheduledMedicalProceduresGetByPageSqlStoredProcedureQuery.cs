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
    public class ScheduledMedicalProceduresGetByPageSqlStoredProcedureQuery : SqlStoredProcedureQuery<ScheduledMedicalProcedureGetByPageRequest, ScheduledMedicalProcedureGetByPageModel>
    {
        public ScheduledMedicalProceduresGetByPageSqlStoredProcedureQuery(IConnectionFactory connectionFactory, IDbCommandInvoker commandInvoker) : base(connectionFactory, commandInvoker)
        {
        }

        public override string Name => DbDictionary.SP.ScheduledMedicalProcedures.GetByPage;

        public override SqlParameter[] CreateSqlParameters(ScheduledMedicalProcedureGetByPageRequest args)
        {
            return new SqlParameter[]
            {
                new SqlParameter("@Take", SqlDbType.Int) { Value = args.Take },
                new SqlParameter("@Skip", SqlDbType.Int) { Value = args.Skip },
                new SqlParameter("@BookingId", SqlDbType.Int) { Value = args.BookingId },
            };
        }

        protected override ScheduledMedicalProcedureGetByPageModel Map(SqlDataReader reader)
        {
            return new ScheduledMedicalProcedureGetByPageModel
            {
                Id = reader.StructField<int>("Id"),
                BookingId = reader.StructField<int>("BookingId"),
                MedicalProcedureId = reader.StructField<int>("MedicalProcedureId"),
                MedicalProcedureName = reader.Field<string>("MedicalProcedureName"),
                UserId = reader.StructField<int>("UserId"),
                UserName = reader.Field<string>("UserName"),
                ScheduledDate = reader.UtcDateTimeField("ScheduledDate").Value,

                CreatedBy = reader.StructField<int>("CreatedBy"),
                ModifiedBy = reader.StructField<int>("CreatedBy"),
                CreatedDate = reader.UtcDateTimeField("CreatedDate").Value,
                ModifiedDate = reader.UtcDateTimeField("ModifiedDate").Value,
            };
        }
    }
}
