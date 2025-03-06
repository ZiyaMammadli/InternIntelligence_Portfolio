using MediatR;

namespace Portfolio.Application.Features.ContactForms.Commands.SubmitForm;

public class SubmitFormCommandRequest:IRequest<Unit>
{
    public Guid UserId { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Message { get; set; }
}
