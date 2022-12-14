using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectTracking.Domain.Entities;

namespace ProjectTracking.Infrastructure.Persistence.DbMap;

public class ProjectDbMap : IEntityTypeConfiguration<ProjectDbModel>
{
    public void Configure(EntityTypeBuilder<ProjectDbModel> builder)
    {
        builder.Property(r => r.StartDate).HasColumnType("TIMESTAMP");
        builder.Property(r => r.EndDate).HasColumnType("TIMESTAMP");
        builder.Property(p => p.ProjectName).HasColumnType("VARCHAR(100)").IsRequired();
        builder.Property(p => p.Status).HasColumnType("VARCHAR(12)").IsRequired();
        
    }

}