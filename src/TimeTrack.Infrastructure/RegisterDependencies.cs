using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TimeTrack.Application.Interfaces;
using TimeTrack.Infrastructure.Services;

namespace TimeTrack.Infrastructure;

public static class RegisterDependencies
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IFirebaseAuthService, FirebaseAuthService>();
        return services;
    }
}
