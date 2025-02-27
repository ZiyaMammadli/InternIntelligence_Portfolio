using Portfolio.Domain.Entities.Common;

namespace Portfolio.Domain.Entitiesl;

public class Achievement : IBaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime? AchievementDate { get; set; }
}
