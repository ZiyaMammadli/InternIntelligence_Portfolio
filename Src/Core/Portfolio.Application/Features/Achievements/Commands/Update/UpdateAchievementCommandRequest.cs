using MediatR;

namespace Portfolio.Application.Features.Achievements.Commands.Update;

public class UpdateAchievementCommandRequest:IRequest<Unit>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime? AchievementDate { get; set; }
}
