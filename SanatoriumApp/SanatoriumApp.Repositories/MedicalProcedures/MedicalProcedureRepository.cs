using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Domain.Common;
using SanatoriumApp.DAL.MedicalProcedures;
using SanatoriumApp.Domain.MedicalProcedures;

namespace SanatoriumApp.Repositories.MedicalProcedures
{
    public class MedicalProcedureRepository : IMedicalProcedureRepository
    {
        private readonly MedicalProceduresCreateSqlStoredProcedureCommand _createCommand;
        private readonly MedicalProceduresGetByIdSqlStoredProcedureQuery _getByIdCommand;
        private readonly MedicalProceduresGetByPageSqlStoredProcedureQuery _getByPageCommand;
        private readonly MedicalProceduresDeleteSqlStoredProcedureCommand _deleteCommand;
        private readonly MedicalProceduresUpdateSqlStoredProcedureCommand _updateCommand;
        private readonly MedicalProceduresGetTotalSqlStoredProcedureScalar _getTotalCommand;
        private readonly MedicalProceduresGetAllSqlStoredProcedureQuery _getAllCommand;

        public MedicalProcedureRepository(
            MedicalProceduresCreateSqlStoredProcedureCommand createCommand
            , MedicalProceduresGetByIdSqlStoredProcedureQuery getByIdCommand
            , MedicalProceduresGetByPageSqlStoredProcedureQuery getByPageCommand
            , MedicalProceduresGetTotalSqlStoredProcedureScalar getTotalCommand
            , MedicalProceduresDeleteSqlStoredProcedureCommand deleteCommand
            , MedicalProceduresUpdateSqlStoredProcedureCommand updateCommand
            , MedicalProceduresGetAllSqlStoredProcedureQuery getAllCommand
            )
        {
            _createCommand = createCommand;
            _getByIdCommand = getByIdCommand;
            _getByPageCommand = getByPageCommand;
            _deleteCommand = deleteCommand;
            _updateCommand = updateCommand;
            _getTotalCommand = getTotalCommand;
            _getAllCommand = getAllCommand;
        }

        public Task Create(MedicalProcedure MedicalProcedure)
        {
            return _createCommand.ExecuteAsync(MedicalProcedure);
        }

        public async Task<MedicalProcedure> GetById(int id)
        {
            var dbResult = await _getByIdCommand.ExecuteAsync(id);
            return dbResult.FirstOrDefault();
        }

        public async Task<KendoGridResponse<MedicalProcedure>> GetByPage(KendoGridRequest request)
        {
            var records = await _getByPageCommand.ExecuteAsync(request);
            var total = await _getTotalCommand.ExecuteAsync();

            var result = new KendoGridResponse<MedicalProcedure>
            {
                Data = records,
                Total = total,
            };

            return result;
        }

        public async Task Delete(int id)
        {
            await _deleteCommand.ExecuteAsync(id);
        }

        public async Task Update(MedicalProcedure request)
        {
            await _updateCommand.ExecuteAsync(request);
        }

        public async Task<ICollection<MedicalProcedure>> GetAll()
        {
            var dbResult = await _getAllCommand.ExecuteAsync();
            return dbResult;
        }
    }
}
