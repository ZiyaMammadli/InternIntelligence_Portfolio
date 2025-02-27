using Portfolio.Domain.Entities.Common;

namespace Portfolio.Domain.Entities;

public class Project : IBaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Link { get; set; }
    public AppUser User { get; set; }
}
