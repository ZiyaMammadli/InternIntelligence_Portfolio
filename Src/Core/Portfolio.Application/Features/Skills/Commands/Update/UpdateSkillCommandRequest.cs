using MediatR;

namespace Portfolio.Application.Features.Skills.Commands.Update;

public class UpdateSkillCommandRequest:IRequest<Unit>
{
    public int Id { get; set; }
    public string Name { get; set; }
}
