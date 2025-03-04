using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Portfolio.Application.Features.Auth.Rules;
using Portfolio.Application.Interfaces.Tokens;
using Portfolio.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Portfolio.Application.Features.Auth.Commands.RefreshToken
{
    public class RefreshTokenCommandHandler : IRequestHandler<RefreshTokenCommandRequest, RefreshTokenCommandResponse>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenService _tokenService;
        private readonly RevokeRules _revokeRules;
        private readonly RefreshTokenRules _refreshTokenRules;
        private readonly IConfiguration _configuration;

        public RefreshTokenCommandHandler(UserManager<AppUser> userManager,ITokenService tokenService,RevokeRules revokeRules,RefreshTokenRules refreshTokenRules,IConfiguration configuration)
        {
            _userManager = userManager;
            _tokenService = tokenService;
            _revokeRules = revokeRules;
            _refreshTokenRules = refreshTokenRules;
            _configuration = configuration;
        }
        public async Task<RefreshTokenCommandResponse> Handle(RefreshTokenCommandRequest request, CancellationToken cancellationToken)
        {
            ClaimsPrincipal? claimsPrincipal =_tokenService.GetPrincipalFromExpiredToken(request.AccessToken);
            await _refreshTokenRules.EnsurePrincipalFoundAsync(claimsPrincipal);

            string? email= claimsPrincipal.FindFirstValue(ClaimTypes.Email);
            AppUser? user = await _userManager.FindByEmailAsync(email);
            await _revokeRules.EnsureUserFoundAsync(user);

            await _refreshTokenRules.EnsureRereshTokenBelongToUserAsync(user.RefreshToken,request.RefreshToken);
            await _refreshTokenRules.EnsureRefreshTokenExpiredTimeAsync(user.RefreshTokenExpiredDate);

            string refreshToken=_tokenService.GenerateRefreshToken();
            JwtSecurityToken token= await _tokenService.GenerateAccessTokenAsync(user);
            string accessToken=new JwtSecurityTokenHandler().WriteToken(token);
            user.RefreshToken = refreshToken;
            int.TryParse(_configuration["JWT:RefreshTokenValidityInDays"], out int RefreshTokenValidityInDays);
            user.RefreshTokenExpiredDate = DateTime.UtcNow.AddDays(RefreshTokenValidityInDays);

            await _userManager.UpdateAsync(user);
            RefreshTokenCommandResponse response = new()
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken,
            };
            return response;
        }
    }
}
