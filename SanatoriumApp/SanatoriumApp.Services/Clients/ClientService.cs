using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Domain.Common;
using SanatoriumApp.Domain.Clients;
using SanatoriumApp.Repositories.Clients;
using SanatoriumApp.Viewmodels.Common;

namespace SanatoriumApp.Services.Clients
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _repository;

        public ClientService(
            IClientRepository repository
            )
        {
            _repository = repository;
        }

        public async Task Create(Client model)
        {
            await _repository.Create(model);
        }

        public async Task Update(Client request)
        {
            await _repository.Update(request);
        }

        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }

        public async Task<KendoGridResponse<Client>> GetByPage(KendoGridRequest request)
        {
            var result = await _repository.GetByPage(request);
            return result;
        }

        public async Task<Client> GetById(int id)
        {
            var result = await _repository.GetById(id);
            return result;
        }

        public async Task<bool> Exists(string passport)
        {
            var user = await _repository.GetByPassport(passport);

            return user != null;
        }

        public async Task<ICollection<DropdownModel>> GetAll()
        {
            var items = await _repository.GetAll();

            var result = items.Select(i => new DropdownModel
            {
                Identifier = i.Id,
                Name = i.LastName + ' ' + i.FirstName,
            }).ToList();

            return result;
        }
    }
}
