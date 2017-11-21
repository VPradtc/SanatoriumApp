using System.Web.Http.Filters;
using Core.Auth.Interceptors;
using Core.Auth.Services;
using Core.Auth.Services.OAuth2;
using Core.Auth.Services.OAuth2.Configuration;
using Core.Auth.Services.OAuth2.Repositories;
using Core.Auth.Services.OAuth2.Tokens;
using Core.Auth.Services.OAuth2.Users;
using Core.Auth.Services.OAuth2.Users.Security;
using Core.DAL.Connections;
using Core.DAL.Execution;
using Core.DAL.Execution.Interception;
using Core.Domain.Auth.Roles.Definition;
using Core.Logging;
using Core.Logging.Serilog;
using Core.Logging.Serilog.Bootstrap.Debug;
using Microsoft.Owin.Security.OAuth;
using Ninject.Modules;
using Ninject.Web.WebApi.FilterBindingSyntax;
using SanatoriumApp.Repositories.Bookings;
using SanatoriumApp.Repositories.Clients;
using SanatoriumApp.Repositories.MedicalProcedures;
using SanatoriumApp.Repositories.Rooms;
using SanatoriumApp.Repositories.ScheduledMedicalProcedures;
using SanatoriumApp.Repositories.Users;
using SanatoriumApp.Services.Auth.MedicalProcedures;
using SanatoriumApp.Services.Auth.Users;
using SanatoriumApp.Services.Bookings;
using SanatoriumApp.Services.Clients;
using SanatoriumApp.Services.Rooms;
using SanatoriumApp.Services.ScheduledMedicalProcedures;
using SanatoriumApp.WebPortal.App_Start.ErrorPolicy;
using SanatoriumApp.WebPortal.Auth;
using SanatoriumApp.WebPortal.Filters.Errors;

namespace SanatoriumApp.IOC
{
    public class NinjectHttpModules
    {
        public static NinjectModule[] Modules => new NinjectModule[]
        {
            new DalModule(),
            new RepositoryModule(),
            new MappingModule(),
            new EmailModule(),
            new AuthModule(),
            new MainModule(),
            new LoggingModule(),
            new DomainModule(),
            new ServiceModule(),

            new DebugModule(),
        };

        public class DomainModule : NinjectModule
        {
            public override void Load()
            {
            }
        }

        public class DalModule : NinjectModule
        {
            public override void Load()
            {
                Kernel.Bind<IConnectionFactory>().To<SqlConnectionFactory>().InSingletonScope();
                Kernel.Bind<DbCommandInvoker>().ToSelf().InSingletonScope();
                Kernel.Bind<IDbCommandInvoker>().To<InterceptableDbCommandInvoker>().InSingletonScope();
                Kernel.Bind<IDbCommandInterceptor>().To<AuthDbCommandInterceptor>().InSingletonScope();
            }
        }

        public class RepositoryModule : NinjectModule
        {
            public override void Load()
            {
                Kernel.Bind<IUserRepository>().To<UserRepository>();
                Kernel.Bind<IRoomRepository>().To<RoomRepository>();
                Kernel.Bind<IMedicalProcedureRepository>().To<MedicalProcedureRepository>();
                Kernel.Bind<IClientRepository>().To<ClientRepository>();
                Kernel.Bind<IBookingRepository>().To<BookingRepository>();
                Kernel.Bind<IRefreshTokenRepository>().To<RefreshTokenRepository>();
                Kernel.Bind<IScheduledMedicalProcedureRepository>().To<ScheduledMedicalProcedureRepository>();
            }
        }

        public class MappingModule : NinjectModule
        {
            public override void Load()
            {
            }
        }

        public class EmailModule : NinjectModule
        {
            public override void Load()
            {
            }
        }

        public class AuthModule : NinjectModule
        {
            public override void Load()
            {
                Kernel.Bind<IRoleDefinitionProvider>().To<RoleDefinitionProvider>().InSingletonScope();

                Kernel.Bind<OAuthAuthorizationServerOptions>().To<LocalOAuth2AuthorizationServerOptions>().InSingletonScope();
                Kernel.Bind<LocalOAuth2AuthorizationServerProvider>().ToSelf().InSingletonScope();
                Kernel.Bind<RefreshTokenProvider>().ToSelf().InSingletonScope();
                Kernel.Bind<IIdentityTokenPropertiesFormater>().To<IdentityTokenPropertiesFormater>().InSingletonScope();

                Kernel.Bind<IAuthService>().To<LocalOAuth2AuthService>().InSingletonScope();

                Kernel.Bind<IAuthUserManager>().To<SanatoriumAppAuthUserManager>().InSingletonScope();
                Kernel.Bind<IApplicationPasswordHasher>().To<CryptoApplicationPasswordHasher>().InSingletonScope();
            }
        }

        public class ServiceModule : NinjectModule
        {
            public override void Load()
            {
                Kernel.Bind<IUserService>().To<UserService>().InSingletonScope();
                Kernel.Bind<IMedicalProcedureService>().To<MedicalProcedureService>().InSingletonScope();
                Kernel.Bind<IRoomService>().To<RoomService>();
                Kernel.Bind<IClientService>().To<ClientService>();
                Kernel.Bind<IBookingService>().To<BookingService>();
                Kernel.Bind<IScheduledMedicalProcedureService>().To<ScheduledMedicalProcedureService>();
            }
        }

        public class MainModule : NinjectModule
        {
            public override void Load()
            {
                Kernel.Bind<IErrorPolicyBootstrapper>().To<ErrorPolicyBootstrapper>().InSingletonScope();

                Kernel.BindHttpFilter<ExceptionInfoDecoratorAttribute>(FilterScope.Controller)
                    .WhenControllerHas<ExceptionDetailAttribute>();
            }
        }

        public class LoggingModule : NinjectModule
        {
            public override void Load()
            {
                Kernel.Bind<IApplicationLogger>().ToMethod(context =>
                {
                    var targetType = context.Request.Target.Member.DeclaringType;
                    var logFactory = (ILoggerFactory)context.Kernel.GetService(typeof(ILoggerFactory));

                    var logger = logFactory.CreateLogger(targetType);
                    return logger;
                });

                Kernel.Bind<SerilogLoggerFactory>().ToSelf().InSingletonScope();
                Kernel.Bind<ILoggerFactory>().ToMethod(context => (SerilogLoggerFactory)context.Kernel.GetService(typeof(SerilogLoggerFactory)));
                Kernel.Bind<ILoggerBootstrapper>().To<DebugSerilogLoggerBootstrapper>().InSingletonScope();
            }
        }

        public class DebugModule : NinjectModule
        {
            public override void Load()
            {
            }
        }

        public class ReleaseModule : NinjectModule
        {
            public override void Load()
            {
            }
        }
    }
}
