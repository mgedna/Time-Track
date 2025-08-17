using Microsoft.AspNetCore.Authentication;
using TimeTrack.Domain;
using TimeTrack.Domain.Configuration;
using TimeTrack.Domain.ExceptionTypes;
using TimeTrack.Infrastructure;
using TimeTrack.Persistence;
using TimeTrack.Application;

namespace TimeTrack.WebApi.Handlers
{
    public static class DIHelper
    {
        public static IServiceCollection AddProjectDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionStrings = configuration.GetSection("ConnectionStrings").Get<ConnectionStrings>();

            services.AddApplicationServices(configuration);

            services.AddInfrastructureServices(configuration);
            services.AddPersistenceServices(connectionStrings ?? throw new CustomNotFound("Connection strings properties are missing from configurable file.")
);
            services.AddDomainDependencies(configuration);
            return services;
        }

        public static IServiceCollection AddFirebaseAuthentication(this IServiceCollection services)
        {
            services.AddAuthentication("Firebase")
                .AddScheme<AuthenticationSchemeOptions, FirebaseAuthenticationHandler>(
                    "Firebase", options => { }
                );
            services.AddAuthorization();
            return services;
        }

        public static IServiceCollection AddExternalServices(this IServiceCollection services, IConfiguration configuration)
        {
            return services;
        }

        public static IServiceCollection DependenciesOrchestrator(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddProjectDependencies(configuration);
            services.AddFirebaseAuthentication();
            services.AddExternalServices(configuration);
            return services;
        }
    }
}
