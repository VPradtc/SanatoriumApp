using System;
using SanatoriumApp.IOC;
using SanatoriumApp.WebPortal.Seed.Users;

namespace SanatoriumApp.WebPortal
{
    public partial class Startup
    {
        public void Seed()
        {
            var userSeedService = NinjectHttpContainer.Resolve<UserSeedService>();
            userSeedService.ExecuteAsync().Wait();
        }
    }
}
