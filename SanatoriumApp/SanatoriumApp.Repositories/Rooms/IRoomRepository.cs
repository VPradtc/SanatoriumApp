using System.Threading.Tasks;
using Core.Domain.Common;
using SanatoriumApp.Domain.Rooms;

namespace SanatoriumApp.Repositories.Rooms
{
    public interface IRoomRepository
    {
        Task Create(Room Room);

        Task<Room> GetById(int id);

        Task<KendoGridResponse<Room>> GetByPage(KendoGridRequest request);

        Task Delete(int id);

        Task Update(Room request);
    }
}
