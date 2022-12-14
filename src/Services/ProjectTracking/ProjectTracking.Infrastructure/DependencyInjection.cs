using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjectTracking.Infrastructure.Persistence;

namespace ProjectTracking.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ProjectTrackingDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnectionString")));

        // services.AddScoped<IRequestRepository, RequestRepository>();

        return services;
    }
    
}