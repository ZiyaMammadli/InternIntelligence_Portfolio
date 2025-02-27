using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Portfolio.Domain.Entities;
using Portfolio.Domain.Entitiesl;
using Portfolio.Persistence.Configurations;

namespace Portfolio.Persistence.Contexts;

public class PortfolioDbContext:IdentityDbContext<AppUser, Role, Guid>
{
    public PortfolioDbContext(DbContextOptions<PortfolioDbContext> options):base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(typeof(AppUserConfiguration).Assembly);
        builder.Entity<IdentityUserLogin<Guid>>().HasKey(l => new { l.LoginProvider, l.ProviderKey });
        builder.Entity<IdentityUserRole<Guid>>().HasKey(r => new { r.UserId, r.RoleId });
        builder.Entity<IdentityUserToken<Guid>>().HasKey(t => new { t.UserId, t.LoginProvider, t.Name });

    }

    public DbSet<AppUser> AppUsers { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<Skill> Skills { get; set; }
    public DbSet<Achievement> Achievements { get; set; }
}
