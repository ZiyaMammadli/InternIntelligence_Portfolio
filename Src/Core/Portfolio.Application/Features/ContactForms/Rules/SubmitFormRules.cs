using Portfolio.Application.Bases;
using Portfolio.Application.Exceptions.Achievement;
using Portfolio.Application.Exceptions.Auth;
using Portfolio.Application.Interfaces.UnitOfWorks;
using Portfolio.Domain.Entities;
using Portfolio.Domain.Entitiesl;

namespace Portfolio.Application.Features.ContactForms.Rules;

public class SubmitFormRules:BaseRule
{
    private readonly IUnitOfWork _unitOfWork;

    public SubmitFormRules(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public Task EnsureUserIdCheckAsync(AppUser user)
    {
        if (user is null) throw new UserNotFoundException(404, "UserId is invalid");
        return Task.CompletedTask;
    }
}
