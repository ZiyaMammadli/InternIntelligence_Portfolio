using Portfolio.Application.Bases;
using Portfolio.Application.Exceptions.Achievement;
using Portfolio.Domain.Entitiesl;

namespace Portfolio.Application.Features.Achievements.Rules;

public class DeleteRules:BaseRule
{
    public Task EnsureAchievementFoundAsync(Achievement achievement)
    {
        if (achievement is null) throw new AchievementNotFoundException(404, "Achievement is not found");
        return Task.CompletedTask;
    }
}
