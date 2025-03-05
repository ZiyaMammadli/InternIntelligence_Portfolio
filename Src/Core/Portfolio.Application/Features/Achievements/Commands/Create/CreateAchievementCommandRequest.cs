using MediatR;

namespace Portfolio.Application.Features.Achievements.Commands.Create;

public class CreateAchievementCommandRequest:IRequest<Unit>
{
    public Guid UserId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime? AchievementDate { get; set; }
}
