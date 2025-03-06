using Portfolio.Application.Bases;
using Portfolio.Application.Exceptions.Skill;
using Portfolio.Domain.Entities;

namespace Portfolio.Application.Features.Skills.Rules;

public class DeleteRules:BaseRule
{
    public Task EnsureSkillFoundAsync(Skill skill)
    {
        if (skill is null) throw new SkillNotFoundException(404, "Skill is not found");
        return Task.CompletedTask;
    }
}
