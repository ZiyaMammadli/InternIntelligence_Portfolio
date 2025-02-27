using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portfolio.Domain.Entities;

namespace Portfolio.Persistence.Configurations;

public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
{
    public void Configure(EntityTypeBuilder<AppUser> builder)
    {
        builder.Property(u=>u.FirstName).IsRequired().HasMaxLength(20);
        builder.Property(u=>u.LastName).IsRequired().HasMaxLength(50);
        builder.Property(u=>u.RefreshToken).IsRequired().HasMaxLength(200);

        builder
            .HasMany(u=>u.Projects)
            .WithOne(p=>p.User)
            .HasForeignKey(p=>p.UserId);
        builder
            .HasMany(u=>u.Skills)
            .WithOne(s=>s.User)
            .HasForeignKey(s=>s.UserId);
        builder
            .HasMany(u=>u.Achievements)
            .WithOne(a=>a.User)
            .HasForeignKey(a=>a.UserId);
    }
}
