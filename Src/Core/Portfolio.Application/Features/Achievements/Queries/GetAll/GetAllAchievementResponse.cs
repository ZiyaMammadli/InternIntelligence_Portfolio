namespace Portfolio.Application.Features.Achievements.Queries.GetAll;

public class GetAllAchievementResponse
{
    public int Id { get; set; }
    public Guid UserId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime? AchievementDate { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }

}
