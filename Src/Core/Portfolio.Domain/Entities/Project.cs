using Portfolio.Domain.Entities.Common;

namespace Portfolio.Domain.Entities;

public class Project : BaseEntity
{
    public Guid UserId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Link { get; set; }
    public AppUser User { get; set; }
}
