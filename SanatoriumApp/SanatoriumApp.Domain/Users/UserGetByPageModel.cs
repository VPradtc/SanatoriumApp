﻿using Core.Domain;
using Core.Domain.Auth.Roles;

namespace SanatoriumApp.Domain.Users
{
    public class UserGetByPageModel : TrackableEntity
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public RoleIdentifier RoleId { get; set; }
    }
}
