using Core.DAL.Connections;
using Core.DAL.Dictionary;
using Core.DAL.Execution;
using Core.DAL.StoredProcedures.Base;

namespace SanatoriumApp.DAL.ScheduledMedicalProcedures
{
    public class ScheduledMedicalProceduresGetTotalSqlStoredProcedureScalar : SqlStoredProcedureScalar<int>
    {
        public ScheduledMedicalProceduresGetTotalSqlStoredProcedureScalar(IConnectionFactory connectionFactory, IDbCommandInvoker commandInvoker) : base(connectionFactory, commandInvoker)
        {
        }

        public override string Name => DbDictionary.SP.ScheduledMedicalProcedures.GetTotal;
    }
}
