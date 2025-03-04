using Portfolio.Application.Bases;
using Portfolio.Application.Exceptions.Auth;
using System.Security.Claims;

namespace Portfolio.Application.Features.Auth.Rules;

public class RefreshTokenRules:BaseRule
{
    public Task EnsurePrincipalFoundAsync(ClaimsPrincipal claimsPrincipal)
    {
        if (claimsPrincipal is null) throw new PrincipalNotFoundException(404, "Principal is not found");
        return Task.CompletedTask;
    }
    public Task EnsureRefreshTokenExpiredTimeAsync(DateTime? expiredTime)
    {
        if (expiredTime <= DateTime.UtcNow) throw new RefreshTokenExpiredException(400, "RefreshToken has expired");
        return Task.CompletedTask;
    }
    public Task EnsureRereshTokenBelongToUserAsync(string userRefreshToken,string requestRefreshToken)
    {
        if (requestRefreshToken != userRefreshToken) throw new RefreshTokenNotFoundException(404, "RefreshToken is not found");
        return Task.CompletedTask;
    }
}
