﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Domain.Common;
using SanatoriumApp.Domain.Rooms;
using SanatoriumApp.Viewmodels.Common;

namespace SanatoriumApp.Services.Rooms
{
    public interface IRoomService
    {
        Task Create(Room model);

        Task Update(Room request);

        Task Delete(int id);

        Task<KendoGridResponse<Room>> GetByPage(KendoGridRequest request);

        Task<Room> GetById(int id);
        Task<ICollection<DropdownModel>> GetAll();
    }
}
