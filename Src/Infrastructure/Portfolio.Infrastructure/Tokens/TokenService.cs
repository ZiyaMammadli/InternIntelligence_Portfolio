using Portfolio.Application.Interfaces.Tokens;
using Portfolio.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Portfolio.Infrastructure.Tokens;

public class TokenService : ITokenService
{
    public Task<JwtSecurityToken> GenerateAccessTokenAsync(AppUser appUser)
    {
        throw new NotImplementedException();
    }

    public string GenerateRefreshToken()
    {
        throw new NotImplementedException();
    }

    public ClaimsPrincipal? GetPrincipalFromExpiredToken(string? token)
    {
        throw new NotImplementedException();
    }
}
