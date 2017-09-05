using System;
using Core.Domain.Auth.Roles;

namespace SanatoriumApp.Domain.Users
{
    public class UserGetByPageModel
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public RoleIdentifier RoleId { get; set; }
    }
}
