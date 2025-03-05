using MediatR;
using Portfolio.Application.Features.Projects.Rules;
using Portfolio.Application.Interfaces.UnitOfWorks;
using Portfolio.Domain.Entities;

namespace Portfolio.Application.Features.Projects.Commands.Update;

public class UpdateProjectCommandHandler : IRequestHandler<UpdateProjectCommandRequest, Unit>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly UpdateRules _updateRules;

    public UpdateProjectCommandHandler(IUnitOfWork unitOfWork,UpdateRules updateRules)
    {
        _unitOfWork = unitOfWork;
        _updateRules = updateRules;
    }
    public async Task<Unit> Handle(UpdateProjectCommandRequest request, CancellationToken cancellationToken)
    {
        Project project=await _unitOfWork.GetReadRepository<Project>().GetSingleAsync(p=>p.Id==request.Id);
        await _updateRules.EnsureProjectFoundAsync(project);
        await _updateRules.EnsureProjectNameCheckAsync(request.Name);
        project.Name = request.Name;
        project.Description = request.Description;
        project.Link = request.Link;
        project.UpdateDated=DateTime.UtcNow;

        await _unitOfWork.GetWriteRepository<Project>().UpdateAsync(project);
        await _unitOfWork.SaveAsync();
        return Unit.Value;
    }
}
