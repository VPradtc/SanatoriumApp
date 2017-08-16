using System.Globalization;
using System.Web.Http;
using Core.Logging;
using Microsoft.Owin;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Ninject.Web.Common.OwinHost;
using Ninject.Web.WebApi.OwinHost;
using Owin;
using Pinguin.IOC;
using Pinguin.WebPortal.Handlers;

[assembly: OwinStartup(typeof(Pinguin.WebPortal.Startup))]

namespace Pinguin.WebPortal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            NinjectHttpContainer.RegisterModules(NinjectHttpModules.Modules);

            ConfigureAuth(app);

            var config = new HttpConfiguration();
            WebApiConfig.Register(config);
            app.UseNinjectMiddleware(NinjectHttpContainer.GetKernel)
               .UseNinjectWebApi(config);

            Seed();

            config.Formatters.JsonFormatter.UseDataContractJsonSerializer = false;
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            config.Formatters.JsonFormatter.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;

            config.Formatters.JsonFormatter.SerializerSettings.Converters.Add(
             new IsoDateTimeConverter() { DateTimeStyles = DateTimeStyles.AssumeUniversal });

            var logBootstrapper = NinjectHttpContainer.Resolve<ILoggerBootstrapper>();
            logBootstrapper.Bootstrap();

            var traceMessageHandler = NinjectHttpContainer.Resolve<TraceMessageHandler>();
            config.MessageHandlers.Add(traceMessageHandler);

            config.EnsureInitialized();
        }
    }
}
