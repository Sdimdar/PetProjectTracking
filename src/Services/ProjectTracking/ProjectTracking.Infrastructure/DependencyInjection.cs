using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjectTracking.Application.Contracts;
using ProjectTracking.Infrastructure.Persistence;
using ProjectTracking.Infrastructure.Repositories;

namespace ProjectTracking.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ProjectTrackingDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnectionString")));

        services.AddScoped<IProjectRepository, ProjectRepository>();
        services.AddScoped<ITaskRepository, TaskRepository>();

        return services;
    }
    
}