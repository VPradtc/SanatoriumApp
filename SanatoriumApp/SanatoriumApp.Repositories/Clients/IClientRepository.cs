using System.Threading.Tasks;
using Core.Domain.Common;
using SanatoriumApp.Domain.Clients;

namespace SanatoriumApp.Repositories.Clients
{
    public interface IClientRepository
    {
        Task Create(Client Client);

        Task<Client> GetById(int id);

        Task<KendoGridResponse<Client>> GetByPage(KendoGridRequest request);

        Task Delete(int id);

        Task Update(Client request);

        Task<Client> GetByPassport(string passport);
    }
}
