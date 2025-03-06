using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portfolio.Domain.Entitiesl;

namespace Portfolio.Persistence.Configurations;

public class AchievementConfiguration : IEntityTypeConfiguration<Achievement>
{
    public void Configure(EntityTypeBuilder<Achievement> builder)
    {
        builder.Property(a => a.Name).IsRequired().HasMaxLength(40);
        builder.Property(a => a.Description).IsRequired().HasMaxLength(100);
    }
}
