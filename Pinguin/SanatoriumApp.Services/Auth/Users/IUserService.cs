using System;
using System.Threading.Tasks;
using SanatoriumApp.Viewmodels.Users;

namespace SanatoriumApp.Services.Auth.Users
{
    public interface IUserService
    {
        Task Create(UserCreateModel model);
        Task<bool> Exists(string email);
    }
}
