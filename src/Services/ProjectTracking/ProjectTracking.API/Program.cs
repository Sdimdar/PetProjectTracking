using ProjectTracking.API;
using ProjectTracking.API.Common;
using ProjectTracking.Application;
using ProjectTracking.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
// Add services to the container.

services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddEndpointsApiExplorer();
services.AddSwagger();
services.SetCorsPolicy();
services.SetAutomapperProfiles();



// Add API services
services.AddApplicationServices();
services.AddInfrastructureServices(builder.Configuration);



var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseMiddleware<GlobalExceptionHandler>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("CorsPolicy");
app.UseAuthorization();

app.MapControllers();

app.Run();