using MediatR;
using Microsoft.AspNetCore.Identity;
using Portfolio.Application.Features.Projects.Rules;
using Portfolio.Application.Interfaces.UnitOfWorks;
using Portfolio.Domain.Entities;

namespace Portfolio.Application.Features.Projects.Commands.Create;

public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommandRequest, Unit>
{
    private readonly UserManager<AppUser> _userManager;
    private readonly IUnitOfWork _unitOfWork;
    private readonly CreateRules _createRules;

    public CreateProjectCommandHandler(UserManager<AppUser> userManager,IUnitOfWork unitOfWork,CreateRules createRules)
    {
        _userManager = userManager;
        _unitOfWork = unitOfWork;
        _createRules = createRules;
    }
    public async Task<Unit> Handle(CreateProjectCommandRequest request, CancellationToken cancellationToken)
    {
        AppUser? user = await _userManager.FindByIdAsync(request.UserId.ToString());
        await _createRules.EnsureUserIdCheckAsync(user);
        await _createRules.EnsureProjectNameCheckAsync(request.Name);
        Project project = new()
        {
            UserId = user.Id,
            Name = request.Name,
            Description = request.Description,
            Link = request.Link,
            CreateDated=DateTime.UtcNow,
            UpdateDated=DateTime.UtcNow,
            IsDeleted=false,
        };
        await _unitOfWork.GetWriteRepository<Project>().AddAsync(project);
        await _unitOfWork.SaveAsync();
        return Unit.Value;
    }
}
