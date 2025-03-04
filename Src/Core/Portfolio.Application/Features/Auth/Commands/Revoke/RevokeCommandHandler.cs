using MediatR;
using Microsoft.AspNetCore.Identity;
using Portfolio.Application.Features.Auth.Rules;
using Portfolio.Domain.Entities;

namespace Portfolio.Application.Features.Auth.Commands.Revoke;

public class RevokeCommandHandler : IRequestHandler<RevokeCommandRequest, Unit>
{
    private readonly UserManager<AppUser> _userManager;
    private readonly RevokeRules _revokeRules;

    public RevokeCommandHandler(UserManager<AppUser> userManager,RevokeRules revokeRules)
    {
        _userManager = userManager;
        _revokeRules = revokeRules;
    }
    public async Task<Unit> Handle(RevokeCommandRequest request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByEmailAsync(request.Email);
        await _revokeRules.EnsureUserFoundAsync(user);
        user.RefreshToken = "null";
        await _userManager.UpdateAsync(user);
        return Unit.Value;
    }
}
