using System.Threading.Tasks;
using Core.Domain.Common;
using SanatoriumApp.Domain.Bookings.ScheduledMedicalProcedures;

namespace SanatoriumApp.Repositories.ScheduledMedicalProcedures
{
    public interface IScheduledMedicalProcedureRepository
    {
        Task Create(ScheduledMedicalProcedure ScheduledMedicalProcedure);

        Task<ScheduledMedicalProcedure> GetById(int id);

        Task<KendoGridResponse<ScheduledMedicalProcedureGetByPageModel>> GetByPage(ScheduledMedicalProcedureGetByPageRequest request);

        Task Delete(int id);

        Task Update(ScheduledMedicalProcedure request);
    }
}
