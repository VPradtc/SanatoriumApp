using System;
using System.Threading.Tasks;
using Core.Domain.Common;
using SanatoriumApp.Domain.Users;
using SanatoriumApp.Viewmodels.Users;

namespace SanatoriumApp.Services.Auth.Users
{
    public interface IUserService
    {
        Task Create(UserCreateModel model);
        Task<bool> Exists(string email);

        Task Update(UserEditModel request);

        Task Delete(int id);

        Task<KendoGridResponse<UserGetByPageModel>> GetByPage(KendoGridRequest request);

        Task<UserEditModel> GetById(int id);
    }
}
