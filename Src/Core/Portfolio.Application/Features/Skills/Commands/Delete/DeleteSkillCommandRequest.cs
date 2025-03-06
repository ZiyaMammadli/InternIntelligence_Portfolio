using MediatR;

namespace Portfolio.Application.Features.Skills.Commands.Delete;

public class DeleteSkillCommandRequest:IRequest<Unit>
{
    public int Id { get; set; } 
}
