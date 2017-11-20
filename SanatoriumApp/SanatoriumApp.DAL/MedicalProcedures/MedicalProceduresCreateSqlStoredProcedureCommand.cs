using System.Data;
using System.Data.SqlClient;
using Core.DAL.Connections;
using Core.DAL.Dictionary;
using Core.DAL.Execution;
using Core.DAL.StoredProcedures.Base;
using SanatoriumApp.Domain.MedicalProcedures;

namespace SanatoriumApp.DAL.MedicalProcedures
{
    public class MedicalProceduresCreateSqlStoredProcedureCommand : SqlStoredProcedureCommand<MedicalProcedure>
    {
        public MedicalProceduresCreateSqlStoredProcedureCommand(IConnectionFactory connectionFactory, IDbCommandInvoker commandInvoker) : base(connectionFactory, commandInvoker)
        {
        }

        public override string Name => DbDictionary.SP.MedicalProcedures.Create;

        public override SqlParameter[] CreateSqlParameters(MedicalProcedure args)
        {
            return new SqlParameter[]
            {
                new SqlParameter("@BaseCost", SqlDbType.Decimal) { Value = args.BaseCost },
                new SqlParameter("@Name", SqlDbType.NVarChar, 128) { Value = args.Name },
            };
        }
    }
}
