using FluentValidation;

namespace Portfolio.Application.Features.Projects.Commands.Delete;

public class DeleteProductCommandValidator:AbstractValidator<DeleteProductCommandRequest>
{
    public DeleteProductCommandValidator()
    {
        RuleFor(u => u.Id)
           .NotEmpty().WithMessage("Id can not be Empty")
           .NotNull().WithMessage("Id can not be null");
    }
}
