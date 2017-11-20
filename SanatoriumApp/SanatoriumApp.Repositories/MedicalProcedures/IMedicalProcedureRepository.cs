using System.Threading.Tasks;
using Core.Domain.Common;
using SanatoriumApp.Domain.MedicalProcedures;

namespace SanatoriumApp.Repositories.MedicalProcedures
{
    public interface IMedicalProcedureRepository
    {
        Task Create(MedicalProcedure MedicalProcedure);

        Task<MedicalProcedure> GetById(int id);

        Task<KendoGridResponse<MedicalProcedure>> GetByPage(KendoGridRequest request);

        Task Delete(int id);

        Task Update(MedicalProcedure request);
    }
}
