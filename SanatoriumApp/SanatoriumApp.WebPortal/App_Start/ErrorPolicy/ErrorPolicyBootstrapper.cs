using System;
using System.Web.Configuration;
using System.Web.Http;

namespace SanatoriumApp.WebPortal.App_Start.ErrorPolicy
{
    public class ErrorPolicyBootstrapper : IErrorPolicyBootstrapper
    {
        public void Bootstrap(HttpConfiguration config)
        {
            var compilationSection = (CompilationSection)System.Configuration.ConfigurationManager.GetSection(@"system.web/compilation");

            bool isDebugEnabled = compilationSection.Debug;

            if (isDebugEnabled)
            {
                config.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;
            }
            else
            {
                config.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.LocalOnly;
            }
        }
    }
}
