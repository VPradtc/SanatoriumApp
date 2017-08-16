using System.Threading.Tasks;
using Core.Domain.Auth;

namespace Core.Auth.Services.OAuth2.Users
{
    public interface IAuthUserManager
    {
        Task<User> GetUserByCredentials(string userName, string password);
    }
}
