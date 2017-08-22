using System;
using System.Web.Http;

namespace Pinguin.WebPortal.App_Start.ErrorPolicy
{
    public interface IErrorPolicyBootstrapper
    {
        void Bootstrap(HttpConfiguration config);
    }
}
