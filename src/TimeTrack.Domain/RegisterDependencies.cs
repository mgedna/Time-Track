using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TimeTrack.Domain.Configuration;

namespace TimeTrack.Domain;

public static class RegisterDependencies
{
    public static IServiceCollection AddDomainDependencies(this IServiceCollection services, IConfiguration configuration) =>

    services.Configure<FirebaseSettings>(options => configuration.GetSection(FirebaseSettings.Key).Bind(options));

}
