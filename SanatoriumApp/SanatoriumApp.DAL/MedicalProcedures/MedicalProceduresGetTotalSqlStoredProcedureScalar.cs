using Core.DAL.Connections;
using Core.DAL.Dictionary;
using Core.DAL.Execution;
using Core.DAL.StoredProcedures.Base;

namespace SanatoriumApp.DAL.MedicalProcedures
{
    public class MedicalProceduresGetTotalSqlStoredProcedureScalar : SqlStoredProcedureScalar<int>
    {
        public MedicalProceduresGetTotalSqlStoredProcedureScalar(IConnectionFactory connectionFactory, IDbCommandInvoker commandInvoker) : base(connectionFactory, commandInvoker)
        {
        }

        public override string Name => DbDictionary.SP.MedicalProcedures.GetTotal;
    }
}
