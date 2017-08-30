using System;
using System.Threading.Tasks;

namespace Core.Auth.Services.Setup
{
    public interface IAuthServiceBootstrapper
    {
        Task BootstrapAsync();
    }
}
