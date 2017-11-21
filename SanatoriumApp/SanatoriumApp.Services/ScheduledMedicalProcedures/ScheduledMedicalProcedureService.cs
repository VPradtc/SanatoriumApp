using System.Threading.Tasks;
using Core.Domain.Common;
using SanatoriumApp.Domain.Bookings.ScheduledMedicalProcedures;
using SanatoriumApp.Repositories.ScheduledMedicalProcedures;

namespace SanatoriumApp.Services.ScheduledMedicalProcedures
{
    public class ScheduledMedicalProcedureService : IScheduledMedicalProcedureService
    {
        private readonly IScheduledMedicalProcedureRepository _repository;

        public ScheduledMedicalProcedureService(
            IScheduledMedicalProcedureRepository repository
            )
        {
            _repository = repository;
        }

        public async Task Create(ScheduledMedicalProcedure model)
        {
            await _repository.Create(model);
        }

        public async Task Update(ScheduledMedicalProcedure request)
        {
            await _repository.Update(request);
        }

        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }

        public async Task<KendoGridResponse<ScheduledMedicalProcedureGetByPageModel>> GetByPage(ScheduledMedicalProcedureGetByPageRequest request)
        {
            var result = await _repository.GetByPage(request);
            return result;
        }

        public async Task<ScheduledMedicalProcedure> GetById(int id)
        {
            var result = await _repository.GetById(id);
            return result;
        }
    }
}
