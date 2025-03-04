using Portfolio.Application.Bases;
using Portfolio.Application.Exceptions.Auth;
using Portfolio.Domain.Entities;

namespace Portfolio.Application.Features.Auth.Rules;

public class RevokeRules:BaseRule
{
    public Task EnsureUserFoundAsync(AppUser user)
    {
        if (user is null) throw new UserNotFoundException(404, "User is not found");
        return Task.CompletedTask;
    }
}
