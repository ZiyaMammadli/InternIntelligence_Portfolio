using Portfolio.Application.Bases;
using Portfolio.Application.Exceptions.Skill;
using Portfolio.Application.Interfaces.UnitOfWorks;
using Portfolio.Domain.Entities;

namespace Portfolio.Application.Features.Skills.Rules;

public class UpdateRules:BaseRule
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateRules(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public Task EnsureSkillFoundAsync(Skill skill)
    {
        if (skill is null)
            throw new SkillNotFoundException(404, "Skill is not found");
        return Task.CompletedTask;
    }
    public async Task EnsureSkillNameCheckAsync(string name)
    {
        var skill = await _unitOfWork.GetReadRepository<Skill>().GetSingleAsync(s => s.Name == name);
        if (skill is not null && skill.Name != name)
            throw new SkillAlreadyExistException(400, "Skill is already exist");
    }
}
