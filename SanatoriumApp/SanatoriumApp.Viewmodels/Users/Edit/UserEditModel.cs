using System;
using Core.Domain.Auth.Roles;

namespace SanatoriumApp.Viewmodels.Users
{
    public class UserEditModel
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public RoleIdentifier RoleId { get; set; }
    }
}
