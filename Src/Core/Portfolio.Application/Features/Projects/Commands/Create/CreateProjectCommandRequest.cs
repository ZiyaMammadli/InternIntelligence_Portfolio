using MediatR;

namespace Portfolio.Application.Features.Projects.Commands.Create;

public class CreateProjectCommandRequest:IRequest<Unit>
{
    public Guid UserId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Link { get; set; }
}
