using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TimeTrack.Domain.Configuration;

namespace TimeTrack.Persistence;

public static class RegisterDependencies
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, ConnectionStrings connectionString)
    => services.AddDbContext<AppDbContext>(options => { options.UseNpgsql(connectionString: connectionString.PostgreSql); });
}
