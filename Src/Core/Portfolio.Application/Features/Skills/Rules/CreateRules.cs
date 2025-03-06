using Portfolio.Application.Bases;
using Portfolio.Application.Exceptions.Auth;
using Portfolio.Application.Exceptions.Skill;
using Portfolio.Application.Interfaces.UnitOfWorks;
using Portfolio.Domain.Entities;

namespace Portfolio.Application.Features.Skills.Rules;

public class CreateRules:BaseRule
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateRules(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public Task EnsureUserIdCheckAsync(AppUser user)
    {
        if (user is null) throw new UserNotFoundException(404, "UserId is invalid");
        return Task.CompletedTask;
    }
    public async Task EnsureSkillNameCheckAsync(string name)
    {
        if (await _unitOfWork.GetReadRepository<Skill>().GetSingleAsync(p => p.Name == name) is not null)
            throw new SkillAlreadyExistException(400, "Skill is already exist");
    }
}
