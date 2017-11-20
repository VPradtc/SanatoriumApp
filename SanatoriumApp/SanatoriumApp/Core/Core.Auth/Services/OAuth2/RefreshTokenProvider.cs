using System;
using System.Threading.Tasks;
using Core.Auth.Services.OAuth2.Repositories;
using Core.Domain.Auth;
using Microsoft.Owin.Security.Infrastructure;

namespace Core.Auth.Services.OAuth2
{
    public class RefreshTokenProvider : IAuthenticationTokenProvider
    {
        private readonly IRefreshTokenRepository _tokenRepository;

        public RefreshTokenProvider(IRefreshTokenRepository tokenRepository)
        {
            _tokenRepository = tokenRepository;
        }

        public void Create(AuthenticationTokenCreateContext context)
        {
            var task = CreateAsync(context);
            task.Wait();
        }

        public async Task CreateAsync(AuthenticationTokenCreateContext tokenContext)
        {
            var refreshTokenId = Guid.NewGuid();
            var refreshTokenLifeTime = tokenContext.OwinContext.Get<int>("as:clientRefreshTokenLifeTime");

            var issuedUtc = DateTime.UtcNow;
            var expiresUtc = DateTime.UtcNow.AddMinutes(refreshTokenLifeTime);

            tokenContext.Ticket.Properties.IssuedUtc = issuedUtc;
            tokenContext.Ticket.Properties.ExpiresUtc = expiresUtc;

            var ticket = tokenContext.SerializeTicket();

            var token = new RefreshToken()
            {
                TokenValue = refreshTokenId,
                Subject = tokenContext.Ticket.Identity.Name,
                IssuedUtc = issuedUtc,
                ExpiresUtc = expiresUtc,
                ProtectedTicket = ticket,
            };

            await _tokenRepository.CreateAsync(token);
            tokenContext.SetToken(refreshTokenId.ToString());
        }

        public void Receive(AuthenticationTokenReceiveContext tokenContext)
        {
            var task = ReceiveAsync(tokenContext);
            task.Wait();
        }

        public async Task ReceiveAsync(AuthenticationTokenReceiveContext tokenContext)
        {
            var tokenId = Guid.Parse(tokenContext.Token);

            var refreshToken = await _tokenRepository.GetByValueAsync(tokenId);

            if (refreshToken != null)
            {
                tokenContext.DeserializeTicket(refreshToken.ProtectedTicket);
                await _tokenRepository.DeleteAsync(refreshToken.Id);
            }
        }
    }
}
