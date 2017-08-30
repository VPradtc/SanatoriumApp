using System;
using Core.Domain.Auth;
using Core.Viewmodels.Mapping;

namespace SanatoriumApp.Viewmodels.Users
{
    public class UserCreateModelMapper : IEntityMapper<User, UserCreateModel>
    {
        public User ToEntity(UserCreateModel viewmodel)
        {
            var entity = new User
            {
                FirstName = viewmodel.FirstName,
                LastName = viewmodel.LastName,

                Email = viewmodel.Email,
                ApiPasswordHash = null,
                ApiPasswordSalt = null,

                RoleId = viewmodel.RoleId,

                IsDeleted = false,
            };

            return entity;
        }
    }
}
