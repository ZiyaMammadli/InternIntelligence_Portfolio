using MediatR;

namespace Portfolio.Application.Features.Projects.Queries.GetAll;

public class GetAllProjectRequest:IRequest<List<GetAllProjectResponse>>
{
}
