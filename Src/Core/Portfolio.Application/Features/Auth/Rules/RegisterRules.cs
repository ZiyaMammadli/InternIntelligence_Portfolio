using Portfolio.Application.Bases;
using Portfolio.Application.Exceptions.Auth;
using Portfolio.Domain.Entities;

namespace Portfolio.Application.Features.Auth.Rules;

public class RegisterRules:BaseRule
{
    public Task EnsureUserExistAsync(AppUser user)
    {
        if (user is not null) throw new UserAlreadyExistException(400,"Email is already exist");
        return Task.CompletedTask;
    }
    public Task EnsureUserNameExistAsync(AppUser user)
    {
        if (user is not null) throw new UserAlreadyExistException(400, "UserName is already exist");
        return Task.CompletedTask;
    }
}
