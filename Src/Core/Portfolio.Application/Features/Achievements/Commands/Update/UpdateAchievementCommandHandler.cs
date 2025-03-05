using MediatR;
using Microsoft.AspNetCore.Identity;
using Portfolio.Application.Features.Achievements.Rules;
using Portfolio.Application.Interfaces.UnitOfWorks;
using Portfolio.Domain.Entities;
using Portfolio.Domain.Entitiesl;

namespace Portfolio.Application.Features.Achievements.Commands.Update;

public class UpdateAchievementCommandHandler : IRequestHandler<UpdateAchievementCommandRequest, Unit>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly UpdateRules _updateRules;

    public UpdateAchievementCommandHandler(IUnitOfWork unitOfWork,UpdateRules updateRules)
    {
        _unitOfWork = unitOfWork;
        _updateRules = updateRules;
    }
    public async Task<Unit> Handle(UpdateAchievementCommandRequest request, CancellationToken cancellationToken)
    {
        Achievement achievement=await _unitOfWork.GetReadRepository<Achievement>().GetSingleAsync(a=>a.Id==request.Id);
        await _updateRules.EnsureAchievementFoundAsync(achievement);
        await _updateRules.EnsureAchievementNameCheckAsync(request.Name);
        achievement.Name = request.Name;
        achievement.Description = request.Description;
        achievement.AchievementDate = request.AchievementDate;
        achievement.UpdateDated=DateTime.UtcNow;
        await _unitOfWork.GetWriteRepository<Achievement>().UpdateAsync(achievement);
        await _unitOfWork.SaveAsync();

        return Unit.Value;
    }
}
