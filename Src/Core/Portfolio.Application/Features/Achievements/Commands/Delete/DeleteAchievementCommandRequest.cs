using MediatR;

namespace Portfolio.Application.Features.Achievements.Commands.Delete;

public class DeleteAchievementCommandRequest:IRequest<Unit>
{
    public int Id { get; set; }
}
