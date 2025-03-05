using Portfolio.Application.Bases;
using Portfolio.Application.Exceptions.Achievement;
using Portfolio.Application.Interfaces.UnitOfWorks;
using Portfolio.Domain.Entitiesl;

namespace Portfolio.Application.Features.Achievements.Rules;

public class UpdateRules:BaseRule
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateRules(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public Task EnsureAchievementFoundAsync(Achievement achievement)
    {
        if (achievement is null)
            throw new AchievementNotFoundException(404, "Achievement is not found");
        return Task.CompletedTask;
    }
    public async Task EnsureAchievementNameCheckAsync(string name)
    {
        var achievement = await _unitOfWork.GetReadRepository<Achievement>().GetSingleAsync(a => a.Name == name);
        if (achievement is not null && achievement.Name != name)
            throw new AchievementAlreadyExistException(400, "AchievementName is already exist");
    }
}
