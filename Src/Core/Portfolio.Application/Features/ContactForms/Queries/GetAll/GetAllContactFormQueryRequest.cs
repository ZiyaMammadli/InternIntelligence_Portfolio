using MediatR;

namespace Portfolio.Application.Features.ContactForms.Queries.GetAll;

public class GetAllContactFormQueryRequest:IRequest<List<GetAllContactFormQueryRepsonse>>
{
}
