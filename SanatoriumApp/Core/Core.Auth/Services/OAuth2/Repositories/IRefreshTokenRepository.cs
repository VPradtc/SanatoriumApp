using System;
using System.Threading.Tasks;
using Core.Domain.Auth;

namespace Core.Auth.Services.OAuth2.Repositories
{
    public interface IRefreshTokenRepository
    {
        Task<int> CreateAsync(RefreshToken entity);
        Task<bool> DeleteAsync(int id);
        Task<RefreshToken> GetByValueAsync(Guid tokenId);
    }
}
