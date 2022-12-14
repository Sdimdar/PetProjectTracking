using Microsoft.EntityFrameworkCore;
using ProjectTracking.Domain.Entities;
using ProjectTracking.Infrastructure.Persistence.DbMap;

namespace ProjectTracking.Infrastructure.Persistence;

public class ProjectTrackingDbContext :DbContext
{
    public DbSet<ProjectDbModel> Projects { get; set; }
    public DbSet<TaskDbModel> TaskDbModels { get; set; }

    public ProjectTrackingDbContext(DbContextOptions<ProjectTrackingDbContext> options):base(options)
    {
        Database.Migrate();
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfiguration(new ProjectDbMap());
        builder.ApplyConfiguration(new TaskDbMap());
    }
    

}