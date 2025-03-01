using Portfolio.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Portfolio.Application.Interfaces.Tokens;

public interface ITokenService
{
    public Task<JwtSecurityToken> GenerateAccessTokenAsync(AppUser appUser);
    public string GenerateRefreshToken();
    public ClaimsPrincipal? GetPrincipalFromExpiredToken(string? token);
}
