namespace Portfolio.Application.Features.ContactForms.Queries.GetAll;

public class GetAllContactFormQueryRepsonse
{
    public int Id { get; set; }
    public Guid UserId { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Message { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime CreateDated { get; set; }
    public DateTime UpdateDated { get; set; }
}
