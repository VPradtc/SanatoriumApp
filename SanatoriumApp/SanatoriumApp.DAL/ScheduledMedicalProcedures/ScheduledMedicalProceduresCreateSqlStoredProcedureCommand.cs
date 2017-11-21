using System.Data;
using System.Data.SqlClient;
using Core.DAL.Connections;
using Core.DAL.Dictionary;
using Core.DAL.Execution;
using Core.DAL.StoredProcedures.Base;
using SanatoriumApp.Domain.Bookings.ScheduledMedicalProcedures;

namespace SanatoriumApp.DAL.ScheduledMedicalProcedures
{
    public class ScheduledMedicalProceduresCreateSqlStoredProcedureCommand : SqlStoredProcedureCommand<ScheduledMedicalProcedure>
    {
        public ScheduledMedicalProceduresCreateSqlStoredProcedureCommand(IConnectionFactory connectionFactory, IDbCommandInvoker commandInvoker) : base(connectionFactory, commandInvoker)
        {
        }

        public override string Name => DbDictionary.SP.ScheduledMedicalProcedures.Create;

        public override SqlParameter[] CreateSqlParameters(ScheduledMedicalProcedure args)
        {
            return new SqlParameter[]
            {
                new SqlParameter("@BookingId", SqlDbType.Int) { Value = args.BookingId },
                new SqlParameter("@MedicalProcedureId", SqlDbType.Int) { Value = args.MedicalProcedureId },
                new SqlParameter("@ScheduledDate", SqlDbType.DateTime2) { Value = args.ScheduledDate },
                new SqlParameter("@UserId", SqlDbType.Int) { Value = args.UserId },
            };
        }
    }
}
