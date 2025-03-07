using MediatR;

namespace Portfolio.Application.Features.Skills.Queries.GetAll;

public class GetAllSkillRequest:IRequest<List<GetAllSkillResponse>>
{
}
