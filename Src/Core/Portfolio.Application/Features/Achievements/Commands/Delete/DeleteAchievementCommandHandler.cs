using MediatR;
using Portfolio.Application.Features.Achievements.Rules;
using Portfolio.Application.Interfaces.UnitOfWorks;
using Portfolio.Domain.Entities;
using Portfolio.Domain.Entitiesl;

namespace Portfolio.Application.Features.Achievements.Commands.Delete;

public class DeleteAchievementCommandHandler : IRequestHandler<DeleteAchievementCommandRequest, Unit>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly DeleteRules _deleteRules;

    public DeleteAchievementCommandHandler(IUnitOfWork unitOfWork,DeleteRules deleteRules)
    {
        _unitOfWork = unitOfWork;
        _deleteRules = deleteRules;
    }
    public async Task<Unit> Handle(DeleteAchievementCommandRequest request, CancellationToken cancellationToken)
    {
        Achievement achievement = await _unitOfWork.GetReadRepository<Achievement>().GetSingleAsync(p => p.Id == request.Id);
        await _deleteRules.EnsureAchievementFoundAsync(achievement);
        achievement.IsDeleted = true;
        await _unitOfWork.GetWriteRepository<Achievement>().UpdateAsync(achievement);
        await _unitOfWork.SaveAsync();
        return Unit.Value;
    }
}
