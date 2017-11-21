using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Domain.Common;
using SanatoriumApp.Domain.Rooms;
using SanatoriumApp.Repositories.Rooms;
using SanatoriumApp.Viewmodels.Common;

namespace SanatoriumApp.Services.Rooms
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _repository;

        public RoomService(
            IRoomRepository repository
            )
        {
            _repository = repository;
        }

        public async Task Create(Room model)
        {
            await _repository.Create(model);
        }

        public async Task Update(Room request)
        {
            await _repository.Update(request);
        }

        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }

        public async Task<KendoGridResponse<Room>> GetByPage(KendoGridRequest request)
        {
            var result = await _repository.GetByPage(request);
            return result;
        }

        public async Task<Room> GetById(int id)
        {
            var result = await _repository.GetById(id);
            return result;
        }

        public async Task<ICollection<DropdownModel>> GetAll()
        {
            var items = await _repository.GetAll();

            var result = items.Select(i => new DropdownModel
            {
                Identifier = i.Id,
                Name = i.Name,
            }).ToList();

            return result;
        }
    }
}
