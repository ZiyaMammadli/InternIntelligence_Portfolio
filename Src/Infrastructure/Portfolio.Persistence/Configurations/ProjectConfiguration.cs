using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portfolio.Domain.Entities;

namespace Portfolio.Persistence.Configurations;

public class ProjectConfiguration : IEntityTypeConfiguration<Project>
{
    public void Configure(EntityTypeBuilder<Project> builder)
    {
        builder.Property(p => p.Name).IsRequired().HasMaxLength(20);
        builder.Property(p => p.Description).IsRequired().HasMaxLength(100);
        builder.Property(u => u.Link).IsRequired().HasMaxLength(250);
    }
}
