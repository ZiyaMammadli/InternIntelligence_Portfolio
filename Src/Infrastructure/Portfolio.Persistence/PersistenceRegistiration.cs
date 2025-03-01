using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Portfolio.Application.Interfaces.Repositories;
using Portfolio.Application.Interfaces.UnitOfWorks;
using Portfolio.Domain.Entities;
using Portfolio.Persistence.Contexts;
using Portfolio.Persistence.Repositories;
using Portfolio.Persistence.UnitOfWorks;

namespace Portfolio.Persistence;

public static class PersistenceRegistiration
{
    public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<PortfolioDbContext>(opt =>
        {
            opt.UseSqlServer(configuration.GetConnectionString("default"));
        }).AddIdentityCore<AppUser>(opt =>
        {
            opt.Password.RequireNonAlphanumeric = true;
            opt.Password.RequireLowercase=true;
            opt.Password.RequireUppercase=true;
            opt.Password.RequiredLength = 8;
            opt.Password.RequireDigit=true;
            opt.User.RequireUniqueEmail = true;
            opt.User.AllowedUserNameCharacters = "qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM0123456789._";

        })
        .AddRoles<Role>()
        .AddEntityFrameworkStores<PortfolioDbContext>();

        services.AddScoped<IUnitOfWork,UnitOfWork>();
        services.AddScoped(typeof(IReadRepository<>),typeof(ReadRepository<>));
        services.AddScoped(typeof(IWriteRepository<>),typeof(WriteRepository<>));
    }
}
