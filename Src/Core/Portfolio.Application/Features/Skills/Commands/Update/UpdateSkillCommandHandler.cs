using MediatR;
using Microsoft.EntityFrameworkCore.Metadata;
using Portfolio.Application.Features.Skills.Rules;
using Portfolio.Application.Interfaces.UnitOfWorks;
using Portfolio.Domain.Entities;

namespace Portfolio.Application.Features.Skills.Commands.Update;

public class UpdateSkillCommandHandler : IRequestHandler<UpdateSkillCommandRequest, Unit>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly UpdateRules _updateRules;

    public UpdateSkillCommandHandler(IUnitOfWork unitOfWork,UpdateRules updateRules)
    {
        _unitOfWork = unitOfWork;
        _updateRules = updateRules;
    }
    public async Task<Unit> Handle(UpdateSkillCommandRequest request, CancellationToken cancellationToken)
    {
        Skill skill= await _unitOfWork.GetReadRepository<Skill>().GetSingleAsync(s=>s.Id==request.Id);
        await _updateRules.EnsureSkillFoundAsync(skill);
        await _updateRules.EnsureSkillNameCheckAsync(request.Name);
        skill.Name = request.Name;
        skill.UpdateDated=DateTime.UtcNow;
        await _unitOfWork.GetWriteRepository<Skill>().UpdateAsync(skill);
        await _unitOfWork.SaveAsync();
        return Unit.Value;
    }
}
