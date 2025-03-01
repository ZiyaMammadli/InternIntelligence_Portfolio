using Portfolio.Domain.Entities.Common;

namespace Portfolio.Domain.Entities;

public class ContactForm:BaseEntity
{
    public Guid UserId { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Message { get; set; }
    public AppUser User { get; set; }
}
