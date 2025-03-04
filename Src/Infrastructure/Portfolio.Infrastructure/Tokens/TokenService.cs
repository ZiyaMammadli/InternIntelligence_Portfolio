using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;
using Microsoft.IdentityModel.Tokens;
using Portfolio.Application.Interfaces.Tokens;
using Portfolio.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Portfolio.Infrastructure.Tokens;

public class TokenService : ITokenService
{
    private readonly UserManager<AppUser> _userManager;
    private TokenSettings _tokenSettings;

    public TokenService(UserManager<AppUser> userManager,IOptions<TokenSettings> options)
    {
        _tokenSettings = options.Value;
        _userManager = userManager;
    }
    public async Task<JwtSecurityToken> GenerateAccessTokenAsync(AppUser user)
    {
        List<Claim> Claims = new List<Claim>()
        {
            new Claim(JwtRegisteredClaimNames.Email,user.Email),
            new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
            new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
        };
        IList<string> roles = await _userManager.GetRolesAsync(user);
        Claims.AddRange(roles.Select(r => new Claim(ClaimTypes.Role, r)));
        SymmetricSecurityKey symmetricSecurityKey = new(Encoding.UTF8.GetBytes(_tokenSettings.SecretKey));

        JwtSecurityToken token = new(
            issuer: _tokenSettings.Issuer,
            audience: _tokenSettings.Audience,
            claims: Claims,
            expires: DateTime.UtcNow.AddMinutes(_tokenSettings.AccessTokenValidityInMinutes),
            signingCredentials:new SigningCredentials(symmetricSecurityKey,SecurityAlgorithms.HmacSha256));

        await _userManager.AddClaimsAsync(user,Claims);
        return token;
    }

    public string GenerateRefreshToken()
    {
        byte[] num = new byte[32];
        using RandomNumberGenerator rng = RandomNumberGenerator.Create();
        rng.GetBytes(num);
        return Convert.ToBase64String(num);
    }

    public ClaimsPrincipal? GetPrincipalFromExpiredToken(string? token)
    {
        TokenValidationParameters validationParameters = new()
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenSettings.SecretKey)),
            ValidateLifetime = false,
        };
        JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
        var principal = handler.ValidateToken(token,validationParameters,out SecurityToken securityToken);
        if(securityToken is not JwtSecurityToken jwtSecurityToken 
            || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
        {
            throw new SecurityTokenException("Token is not found");
        }
        return principal;
    }
}
