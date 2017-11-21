using System.Linq;
using System.Threading.Tasks;
using Core.Domain.Common;
using SanatoriumApp.DAL.ScheduledMedicalProcedures;
using SanatoriumApp.Domain.Bookings.ScheduledMedicalProcedures;

namespace SanatoriumApp.Repositories.ScheduledMedicalProcedures
{
    public class ScheduledMedicalProcedureRepository : IScheduledMedicalProcedureRepository
    {
        private readonly ScheduledMedicalProceduresCreateSqlStoredProcedureCommand _createCommand;
        private readonly ScheduledMedicalProceduresGetByIdSqlStoredProcedureQuery _getByIdCommand;
        private readonly ScheduledMedicalProceduresGetByPageSqlStoredProcedureQuery _getByPageCommand;
        private readonly ScheduledMedicalProceduresDeleteSqlStoredProcedureCommand _deleteCommand;
        private readonly ScheduledMedicalProceduresUpdateSqlStoredProcedureCommand _updateCommand;
        private readonly ScheduledMedicalProceduresGetTotalSqlStoredProcedureScalar _getTotalCommand;

        public ScheduledMedicalProcedureRepository(
            ScheduledMedicalProceduresCreateSqlStoredProcedureCommand createCommand
            , ScheduledMedicalProceduresGetByIdSqlStoredProcedureQuery getByIdCommand
            , ScheduledMedicalProceduresGetByPageSqlStoredProcedureQuery getByPageCommand
            , ScheduledMedicalProceduresGetTotalSqlStoredProcedureScalar getTotalCommand
            , ScheduledMedicalProceduresDeleteSqlStoredProcedureCommand deleteCommand
            , ScheduledMedicalProceduresUpdateSqlStoredProcedureCommand updateCommand
            )
        {
            _createCommand = createCommand;
            _getByIdCommand = getByIdCommand;
            _getByPageCommand = getByPageCommand;
            _deleteCommand = deleteCommand;
            _updateCommand = updateCommand;
            _getTotalCommand = getTotalCommand;
        }

        public Task Create(ScheduledMedicalProcedure ScheduledMedicalProcedure)
        {
            return _createCommand.ExecuteAsync(ScheduledMedicalProcedure);
        }

        public async Task<ScheduledMedicalProcedure> GetById(int id)
        {
            var dbResult = await _getByIdCommand.ExecuteAsync(id);
            return dbResult.FirstOrDefault();
        }

        public async Task<KendoGridResponse<ScheduledMedicalProcedureGetByPageModel>> GetByPage(ScheduledMedicalProcedureGetByPageRequest request)
        {
            var records = await _getByPageCommand.ExecuteAsync(request);
            var total = await _getTotalCommand.ExecuteAsync();

            var result = new KendoGridResponse<ScheduledMedicalProcedureGetByPageModel>
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

        public async Task Update(ScheduledMedicalProcedure request)
        {
            await _updateCommand.ExecuteAsync(request);
        }
    }
}
