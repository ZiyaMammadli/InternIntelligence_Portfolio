using MediatR;

namespace Portfolio.Application.Features.Skills.Commands.Create;

public class CreateSkillCommandRequest:IRequest<Unit>
{
    public Guid UserId { get; set; }
    public string Name { get; set; }
}
