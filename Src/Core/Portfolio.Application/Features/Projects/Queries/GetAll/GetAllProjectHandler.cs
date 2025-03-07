using MediatR;
using Portfolio.Application.Interfaces.UnitOfWorks;
using Portfolio.Domain.Entities;

namespace Portfolio.Application.Features.Projects.Queries.GetAll;

public class GetAllProjectHandler : IRequestHandler<GetAllProjectRequest, List<GetAllProjectResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllProjectHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<List<GetAllProjectResponse>> Handle(GetAllProjectRequest request, CancellationToken cancellationToken)
    {
        List<Project> projects = await _unitOfWork.GetReadRepository<Project>().GetAllAsync();
        List<GetAllProjectResponse> responses=projects.Select(p=> new GetAllProjectResponse()
        {
            Id = p.Id,
            UserId = p.UserId,
            Name = p.Name,
            Description = p.Description,
            Link=p.Link,
            IsDeleted = p.IsDeleted,
            CreatedDate=p.CreateDated,
            UpdatedDate=p.UpdateDated,
        }).ToList();

        return responses;
    }
}
