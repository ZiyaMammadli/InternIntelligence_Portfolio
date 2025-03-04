using FluentValidation;

namespace Portfolio.Application.Features.Projects.Commands.Create;

public class CreateProjectCommandValidator : AbstractValidator<CreateProjectCommandRequest>
{
    public CreateProjectCommandValidator()
    {
        RuleFor(c => c.UserId)
            .NotEmpty().WithMessage("UserId can not be Empty")
            .NotNull().WithMessage("UserId can not be null");
        RuleFor(c => c.Name)
            .NotEmpty().WithMessage("Name can not be Empty")
            .NotNull().WithMessage("Name can not be null");
        RuleFor(c => c.Description)
            .NotEmpty().WithMessage("Description can not be Empty")
            .NotNull().WithMessage("Description can not be null");
        RuleFor(c => c.Link)
            .NotEmpty().WithMessage("Link can not be Empty")
            .NotNull().WithMessage("Link can not be null");
    }
}
