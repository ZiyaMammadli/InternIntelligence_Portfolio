using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Portfolio.Application.Interfaces.Tokens;
using Portfolio.Infrastructure.Tokens;
using System.Text;

namespace Portfolio.Infrastructure;

public static class InfrastructureRegistration
{
    public static void AddInfrastructure(this IServiceCollection services,IConfiguration config)
    {
        services.Configure<TokenSettings>(config.GetSection("JWT"));
        services.AddTransient<ITokenService, TokenService>();
        services.AddAuthentication(opt =>
        {
            opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, opt =>
        {
            opt.SaveToken = true;
            opt.TokenValidationParameters = new()
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JWT:SecretKey"])),
                ValidateLifetime = false,
                ValidIssuer = config["JWT:Issuer"],
                ValidAudience = config["JWT:Audience"],
                ClockSkew = TimeSpan.Zero,
            };
        });
    }
}
