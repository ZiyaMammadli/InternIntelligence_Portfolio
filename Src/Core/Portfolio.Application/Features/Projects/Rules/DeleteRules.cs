using Portfolio.Application.Bases;
using Portfolio.Application.Exceptions.Project;
using Portfolio.Domain.Entities;

namespace Portfolio.Application.Features.Projects.Rules;

public class DeleteRules:BaseRule
{
    public Task EnsureProjectFoundAsync(Project project)
    {
        if (project is null) throw new ProjectNotFoundException(404, "Project is not found");
        return Task.CompletedTask;
    }
}
