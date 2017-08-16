using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Auth.Services.Models
{
    public interface IAuthServiceUser : IDisposable
    {
        int DbRecordId { get; set; }
        int? DbCompanyId { get; set; }
        string UserName { get; }

        Task<IEnumerable<string>> GetGroupsAsync();
    }
}
