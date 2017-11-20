using System;
using System.Web.Http;

namespace SanatoriumApp.WebPortal.App_Start.ErrorPolicy
{
    public interface IErrorPolicyBootstrapper
    {
        void Bootstrap(HttpConfiguration config);
    }
}
