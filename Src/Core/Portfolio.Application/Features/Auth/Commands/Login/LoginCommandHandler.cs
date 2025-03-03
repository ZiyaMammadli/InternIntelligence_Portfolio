using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Portfolio.Application.Features.Auth.Rules;
using Portfolio.Application.Interfaces.Tokens;
using Portfolio.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;

namespace Portfolio.Application.Features.Auth.Commands.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommandRequest, LoginCommandResponse>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly LoginRules _loginRules;
        private readonly ITokenService _tokenService;
        private readonly IConfiguration _configuration;

        public LoginCommandHandler(UserManager<AppUser> userManager,LoginRules loginRules,ITokenService tokenService,IConfiguration configuration)
        {
            _userManager = userManager;            
            _loginRules = loginRules;
            _tokenService = tokenService;
            _configuration = configuration;
        }
        public async Task<LoginCommandResponse> Handle(LoginCommandRequest request, CancellationToken cancellationToken)
        {
            AppUser? user=await _userManager.FindByEmailAsync(request.Email);
            await _loginRules.EnsureUserExistAsync(user);
            bool checkPassword=await _userManager.CheckPasswordAsync(user,request.Password);
            await _loginRules.EnsurePasswordCheckAsync(checkPassword);
            string refreshToken=_tokenService.GenerateRefreshToken();
            JwtSecurityToken token= await _tokenService.GenerateAccessTokenAsync(user);
            string accessToken=new JwtSecurityTokenHandler().WriteToken(token);
            user.RefreshToken = refreshToken;
            _=int.TryParse(_configuration["JWT:RefreshTokenValidityInDays"], out int RefreshTokenValidityInDays);
            user.RefreshTokenExpiredDate = DateTime.UtcNow.AddDays(RefreshTokenValidityInDays);
            await _userManager.UpdateAsync(user);
            await _userManager.UpdateSecurityStampAsync(user);
            LoginCommandResponse response = new LoginCommandResponse()
            {
                RefreshToken = refreshToken,
                AccessToken = accessToken,
                Expiration = token.ValidTo
            };
            return response;
        }
    }
}
