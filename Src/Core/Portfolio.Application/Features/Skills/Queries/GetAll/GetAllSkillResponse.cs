namespace Portfolio.Application.Features.Skills.Queries.GetAll;

public class GetAllSkillResponse
{
    public int Id { get; set; }
    public Guid UserId { get; set; }
    public string Name { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
}
