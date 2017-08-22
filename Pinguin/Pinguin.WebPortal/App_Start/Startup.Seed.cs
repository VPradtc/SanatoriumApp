using System;
using Pinguin.IOC;
using Pinguin.WebPortal.Seed.Users;

namespace Pinguin.WebPortal
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
