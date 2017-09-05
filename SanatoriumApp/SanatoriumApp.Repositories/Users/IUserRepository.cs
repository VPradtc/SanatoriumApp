﻿using System;
using System.Threading.Tasks;
using Core.Domain.Auth;
using Core.Domain.Common;
using SanatoriumApp.Domain.Users;
using SanatoriumApp.Viewmodels.Users;

namespace SanatoriumApp.Repositories.Users
{
    public interface IUserRepository
    {
        Task<User> GetByEmail(string email);
        Task Create(User user);

        Task<UserEditModel> GetById(int id);

        Task<KendoGridResponse<UserGetByPageModel>> GetByPage(KendoGridRequest request);

        Task Delete(int id);

        Task Update(UserEditModel request);
    }
}
