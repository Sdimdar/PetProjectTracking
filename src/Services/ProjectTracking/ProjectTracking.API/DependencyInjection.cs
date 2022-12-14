using Microsoft.OpenApi.Models;

namespace ProjectTracking.API;

public static class DependencyInjection
{
    public static IServiceCollection AddSwagger(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "PlaceEvalution", Version = "v1" });
        });
        return services;
    }
    
}