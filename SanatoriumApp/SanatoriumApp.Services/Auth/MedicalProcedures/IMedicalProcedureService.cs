using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Domain.Common;
using SanatoriumApp.Domain.MedicalProcedures;
using SanatoriumApp.Viewmodels.Common;

namespace SanatoriumApp.Services.Auth.MedicalProcedures
{
    public interface IMedicalProcedureService
    {
        Task Create(MedicalProcedure model);

        Task Update(MedicalProcedure request);

        Task Delete(int id);

        Task<KendoGridResponse<MedicalProcedure>> GetByPage(KendoGridRequest request);

        Task<MedicalProcedure> GetById(int id);

        Task<ICollection<DropdownModel>> GetAll();
    }
}
