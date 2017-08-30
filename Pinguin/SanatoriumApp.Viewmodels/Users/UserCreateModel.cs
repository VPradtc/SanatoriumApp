using System;
using Core.Domain.Auth.Roles;

namespace SanatoriumApp.Viewmodels.Users
{
    public class UserCreateModel
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Password { get; set; }

        public RoleIdentifier RoleId { get; set; }
    }
}
