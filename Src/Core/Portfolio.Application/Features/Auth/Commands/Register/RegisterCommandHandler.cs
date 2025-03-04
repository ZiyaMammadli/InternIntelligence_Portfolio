using MediatR;
using Microsoft.AspNetCore.Identity;
using Portfolio.Application.Features.Auth.Rules;
using Portfolio.Domain.Entities;

namespace Portfolio.Application.Features.Auth.Commands.Register;

public class RegisterCommandHandler : IRequestHandler<RegisterCommandRequest, Unit>
{
    private readonly UserManager<AppUser> _userManager;
    private readonly RegisterRules _registerRules;
    private readonly RoleManager<Role> _roleManager;

    public RegisterCommandHandler(UserManager<AppUser> userManager,RegisterRules registerRules,RoleManager<Role> roleManager)
    {
        _userManager = userManager;
        _registerRules = registerRules;
        _roleManager = roleManager;
    }
    public async Task<Unit> Handle(RegisterCommandRequest request, CancellationToken cancellationToken)
    {
        AppUser? user=await _userManager.FindByEmailAsync(request.Email);
        await _registerRules.EnsureUserExistAsync(user);
        AppUser? userr=await _userManager.FindByNameAsync(request.UserName);
        await _registerRules.EnsureUserNameExistAsync(userr);
        AppUser appUser = new()
        {
            UserName = request.UserName,
            Email = request.Email,  
            FirstName = request.FirstName,
            LastName = request.LastName,
            IsDeleted=false,
            RefreshToken="null",
            RefreshTokenExpiredDate=DateTime.UtcNow,
        };
        var result = await _userManager.CreateAsync(appUser, request.Password);
        if (result.Succeeded)
        {
            if (!await _roleManager.RoleExistsAsync("member"))
            {
                Role role = new Role()
                {
                    Id = Guid.NewGuid(),
                    Name = "member",
                    NormalizedName = "MEMBER",
                    ConcurrencyStamp = Guid.NewGuid().ToString(),
                };
                await _roleManager.CreateAsync(role);
            }
            await _userManager.AddToRoleAsync(appUser, "member");
        }
        return Unit.Value;
    }
}
