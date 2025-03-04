using MediatR;

namespace Portfolio.Application.Features.Projects.Commands.Delete;

public class DeleteProductCommandRequest:IRequest<Unit>
{
    public int Id { get; set; }
}
