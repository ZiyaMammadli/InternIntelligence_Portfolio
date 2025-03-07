using MediatR;
using Microsoft.EntityFrameworkCore.Metadata;
using Portfolio.Application.Interfaces.UnitOfWorks;
using Portfolio.Domain.Entitiesl;

namespace Portfolio.Application.Features.Achievements.Queries.GetAll;

public class GetAllAchievementHandler : IRequestHandler<GetAllAchievementRequest, List<GetAllAchievementResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllAchievementHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<GetAllAchievementResponse>> Handle(GetAllAchievementRequest request, CancellationToken cancellationToken)
    {
        List<Achievement> achievements = await _unitOfWork.GetReadRepository<Achievement>().GetAllAsync();
        List<GetAllAchievementResponse> responses = achievements.Select(a => new GetAllAchievementResponse()
        {
            Id = a.Id,
            Name = a.Name,
            UserId = a.UserId,
            Description = a.Description,
            IsDeleted = a.IsDeleted,
            AchievementDate = a.AchievementDate,
            UpdatedDate = a.UpdateDated,
            CreatedDate = a.CreateDated,
        }).ToList();

        return responses;
    }
}
