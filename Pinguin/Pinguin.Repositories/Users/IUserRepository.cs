using System;
using System.Threading.Tasks;
using Core.Domain.Auth;

namespace Pinguin.Repositories.Users
{
    public interface IUserRepository
    {
        Task<User> GetByEmail(string email);
        Task Create(User user);
    }
}
