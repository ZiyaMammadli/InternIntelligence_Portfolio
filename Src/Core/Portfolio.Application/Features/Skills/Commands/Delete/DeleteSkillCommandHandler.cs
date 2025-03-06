using MediatR;
using Portfolio.Application.Features.Skills.Rules;
using Portfolio.Application.Interfaces.UnitOfWorks;
using Portfolio.Domain.Entities;

namespace Portfolio.Application.Features.Skills.Commands.Delete;

public class DeleteSkillCommandHandler : IRequestHandler<DeleteSkillCommandRequest, Unit>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly DeleteRules _deleteRules;

    public DeleteSkillCommandHandler(IUnitOfWork unitOfWork,DeleteRules deleteRules)
    {
        _unitOfWork = unitOfWork;
        _deleteRules = deleteRules;
    }
    public async Task<Unit> Handle(DeleteSkillCommandRequest request, CancellationToken cancellationToken)
    {
        Skill skill=await _unitOfWork.GetReadRepository<Skill>().GetSingleAsync(s=>s.Id==request.Id);
        await _deleteRules.EnsureSkillFoundAsync(skill);
        skill.IsDeleted = true;
        await _unitOfWork.GetWriteRepository<Skill>().UpdateAsync(skill);
        await _unitOfWork.SaveAsync();
        return Unit.Value;
    }
}
