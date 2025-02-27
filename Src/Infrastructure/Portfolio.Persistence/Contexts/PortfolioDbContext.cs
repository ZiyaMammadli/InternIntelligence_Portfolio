using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Portfolio.Domain.Entities;
using Portfolio.Domain.Entitiesl;

namespace Portfolio.Persistence.Contexts;

public class PortfolioDbContext:IdentityDbContext
{
    public PortfolioDbContext(DbContextOptions<PortfolioDbContext> options):base(options) { }

    public DbSet<AppUser> AppUsers { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<Skill> Skills { get; set; }
    public DbSet<Achievement> Achievements { get; set; }
}
