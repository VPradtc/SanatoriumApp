using System.Threading.Tasks;
using Core.Domain.Common;
using SanatoriumApp.Domain.Bookings.ScheduledMedicalProcedures;

namespace SanatoriumApp.Services.ScheduledMedicalProcedures
{
    public interface IScheduledMedicalProcedureService
    {
        Task Create(ScheduledMedicalProcedure model);

        Task Update(ScheduledMedicalProcedure request);

        Task Delete(int id);

        Task<KendoGridResponse<ScheduledMedicalProcedureGetByPageModel>> GetByPage(ScheduledMedicalProcedureGetByPageRequest request);

        Task<ScheduledMedicalProcedure> GetById(int id);
    }
}
