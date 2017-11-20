using System.Threading.Tasks;
using Core.Domain.Common;
using SanatoriumApp.Domain.Clients;

namespace SanatoriumApp.Services.Clients
{
    public interface IClientService
    {
        Task Create(Client model);

        Task Update(Client request);

        Task Delete(int id);

        Task<KendoGridResponse<Client>> GetByPage(KendoGridRequest request);

        Task<Client> GetById(int id);

        Task<bool> Exists(string passport);
    }
}
