using System;
using System.Threading.Tasks;
using Pinguin.Viewmodels.Users;

namespace Pinguin.Services.Auth.Users
{
    public interface IUserService
    {
        Task Create(UserCreateModel model);
        Task<bool> Exists(string email);
    }
}
