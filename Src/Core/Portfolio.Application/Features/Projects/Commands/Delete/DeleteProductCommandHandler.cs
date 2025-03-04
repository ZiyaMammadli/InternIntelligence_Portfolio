using MediatR;
using Portfolio.Application.Features.Projects.Rules;
using Portfolio.Application.Interfaces.UnitOfWorks;
using Portfolio.Domain.Entities;

namespace Portfolio.Application.Features.Projects.Commands.Delete;

internal class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommandRequest, Unit>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly DeleteRules _deleteRules;

    public DeleteProductCommandHandler(IUnitOfWork unitOfWork,DeleteRules deleteRules)
    {
        _unitOfWork = unitOfWork;
        _deleteRules = deleteRules;
    }
    public async Task<Unit> Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
    {
        Project project= await _unitOfWork.GetReadRepository<Project>().GetSingleAsync(p => p.Id == request.Id);
        await _deleteRules.EnsureProjectFoundAsync(project);
        project.IsDeleted = true;
        await _unitOfWork.GetWriteRepository<Project>().UpdateAsync(project);
        await _unitOfWork.SaveAsync();
        return Unit.Value;
    }
}
