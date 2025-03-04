using Portfolio.Application.Bases;
using Portfolio.Application.Exceptions.Auth;
using Portfolio.Application.Exceptions.Project;
using Portfolio.Application.Interfaces.UnitOfWorks;
using Portfolio.Domain.Entities;

namespace Portfolio.Application.Features.Projects.Rules;

public class CreateRules:BaseRule
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateRules(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public Task EnsureUserIdCheckAsync(AppUser user)
    {
        if (user is null) throw new UserNotFoundException(404, "UserId is invalid"); 
        return Task.CompletedTask;
    }
    public async Task EnsureProjectNameCheckAsync(string name)
    {
        if (await _unitOfWork.GetReadRepository<Project>().GetSingleAsync(p => p.Name == name) is null)
            throw new ProjectAlreadyExistException(400, "ProjectName is already exist");
    }
}
