namespace Portfolio.Domain.Entities.Common;

public class BaseEntity:IBaseEntity
{
    public int Id { get; set; } 
    public bool IsDeleted { get; set; }
    public DateTime CreateDated { get; set; }
    public DateTime UpdateDated { get; set; }
}
