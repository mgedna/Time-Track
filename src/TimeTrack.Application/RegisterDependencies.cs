using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TimeTrack.Application.Mappings;

namespace TimeTrack.Application;

public static class RegisterDependencies
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration) =>
    
    services.AddAutoMapper(cfg => cfg.AddProfile<MappingProfile>());

}
