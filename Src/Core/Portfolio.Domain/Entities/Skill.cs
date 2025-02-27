using Portfolio.Domain.Entities.Common;

namespace Portfolio.Domain.Entities;

public class Skill : IBaseEntity
{
    public Guid UserId { get; set; }
    public string Name { get; set; }
    public AppUser User { get; set; }
}
