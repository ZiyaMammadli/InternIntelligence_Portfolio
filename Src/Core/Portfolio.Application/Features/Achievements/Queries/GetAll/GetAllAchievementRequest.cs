using MediatR;

namespace Portfolio.Application.Features.Achievements.Queries.GetAll;

public class GetAllAchievementRequest:IRequest<List<GetAllAchievementResponse>>
{
}
