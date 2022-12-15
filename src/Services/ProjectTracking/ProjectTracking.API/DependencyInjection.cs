using AutoMapper;
using Microsoft.OpenApi.Models;
using ProjectTracking.API.Mapping;

namespace ProjectTracking.API;

public static class DependencyInjection
{
    public static IServiceCollection AddSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "PlaceEvalution", Version = "v1" });
            c.EnableAnnotations();
        });
        return services;
    }
    
    public static IServiceCollection SetCorsPolicy(this IServiceCollection services)
    {
        services.AddCors(options => options.AddPolicy("CorsPolicy", policy =>
        {
            policy.WithOrigins("http://localhost:8080").AllowAnyMethod().AllowAnyHeader().AllowCredentials();
            policy.WithOrigins("http://localhost").AllowAnyMethod().AllowAnyHeader().AllowCredentials();
        }));
        return services;
    }
    
    public static IServiceCollection SetAutomapperProfiles(this IServiceCollection services)
    {
        services.AddSingleton(provider => new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new MappingProfile());
        }).CreateMapper());
        return services;
    }
    
}