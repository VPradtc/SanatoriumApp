using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Domain.Auth.Roles;
using SanatoriumApp.API.Seed.Core;
using SanatoriumApp.Services.Auth.Users;
using SanatoriumApp.Viewmodels.Users;

namespace SanatoriumApp.WebPortal.Seed.Users
{
    public class UserSeedService : SeedService<UserCreateModel>
    {
        private readonly IUserService _userService;

        public UserSeedService(IUserService userService) : base()
        {
            _userService = userService;
        }

        protected override ICollection<UserCreateModel> CreateSeedData()
        {
            var entities = new List<UserCreateModel>
            {
                new UserCreateModel
                {
                    Email = "admin@ix.com",
                    FirstName = "Admin",
                    LastName= "Admin",
                    Password = "admin1",
                    RoleId = RoleIdentifier.Admin,
                },
            };

            return entities;
        }

        protected override async Task ExecuteInternalAsync(ICollection<UserCreateModel> data)
        {
            foreach (var user in data)
            {
                var userExists = await _userService.Exists(user.Email);
                if (!userExists)
                {
                    await _userService.Create(user);
                }
            }
        }
    }
}
