using Portfolio.Application.Bases;
using Portfolio.Application.Exceptions.Auth;
using Portfolio.Domain.Entities;

namespace Portfolio.Application.Features.Auth.Rules;

public class LoginRules:BaseRule
{
    public Task EnsureUserExistAsync(AppUser user)
    {
        if (user is null) throw new UserNotFoundException(404,"User is not found");
        return Task.CompletedTask;
    }
    public Task EnsurePasswordCheckAsync(bool checkPassword)
    {
        if (checkPassword is false) throw new InvalidCredentialsException(404, "Email or Password is incorrect");
        return Task.CompletedTask;
    }
}
