using MediatR;
using Portfolio.Application.Interfaces.UnitOfWorks;
using Portfolio.Domain.Entities;

namespace Portfolio.Application.Features.Skills.Queries.GetAll;

public class GetAllSkillHandler : IRequestHandler<GetAllSkillRequest, List<GetAllSkillResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllSkillHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<List<GetAllSkillResponse>> Handle(GetAllSkillRequest request, CancellationToken cancellationToken)
    {
        List<Skill> skills=await _unitOfWork.GetReadRepository<Skill>().GetAllAsync();
        List<GetAllSkillResponse> responses = skills.Select(s=> new GetAllSkillResponse()
        {
            Id = s.Id,
            UserId = s.UserId,
            Name = s.Name,
            IsDeleted = s.IsDeleted,
            CreatedDate=s.CreateDated,
            UpdatedDate=s.UpdateDated,
        }).ToList();
        return responses;
    }
}
