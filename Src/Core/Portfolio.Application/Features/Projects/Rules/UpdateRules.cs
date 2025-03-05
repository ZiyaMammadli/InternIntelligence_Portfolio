using Portfolio.Application.Bases;
using Portfolio.Application.Exceptions.Project;
using Portfolio.Application.Interfaces.UnitOfWorks;
using Portfolio.Domain.Entities;

namespace Portfolio.Application.Features.Projects.Rules;

public class UpdateRules:BaseRule
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateRules(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public  Task EnsureProjectFoundAsync(Project project)
    {
        if (project is null)
            throw new ProjectNotFoundException(404, "Project is not found");
        return Task.CompletedTask;
    }
    public async Task EnsureProjectNameCheckAsync(string name)
    {
        var project = await _unitOfWork.GetReadRepository<Project>().GetSingleAsync(p => p.Name == name);
        if (project is not null && project.Name != name)
            throw new ProjectAlreadyExistException(400, "ProjectName is already exist");
    }
} 
