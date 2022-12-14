using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectTracking.Domain.Entities;

namespace ProjectTracking.Infrastructure.Persistence.DbMap;

public class TaskDbMap:IEntityTypeConfiguration<TaskDbModel>
{
    public void Configure(EntityTypeBuilder<TaskDbModel> builder)
    {
        builder.Property(p => p.TaskName).HasColumnType("VARCHAR(100)").IsRequired();
        builder.Property(p => p.Status).HasColumnType("VARCHAR(12)").IsRequired();
    }
}