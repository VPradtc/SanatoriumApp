using System.Threading.Tasks;
using Core.Domain.Common;
using SanatoriumApp.Domain.MedicalProcedures;
using SanatoriumApp.Repositories.MedicalProcedures;

namespace SanatoriumApp.Services.Auth.MedicalProcedures
{
    public class MedicalProcedureService : IMedicalProcedureService
    {
        private readonly IMedicalProcedureRepository _repository;

        public MedicalProcedureService(
            IMedicalProcedureRepository repository
            )
        {
            _repository = repository;
        }

        public async Task Create(MedicalProcedure model)
        {
            await _repository.Create(model);
        }

        public async Task Update(MedicalProcedure request)
        {
            await _repository.Update(request);
        }

        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }

        public async Task<KendoGridResponse<MedicalProcedure>> GetByPage(KendoGridRequest request)
        {
            var result = await _repository.GetByPage(request);
            return result;
        }

        public async Task<MedicalProcedure> GetById(int id)
        {
            var result = await _repository.GetById(id);
            return result;
        }
    }
}
