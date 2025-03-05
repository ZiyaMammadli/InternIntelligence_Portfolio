using FluentValidation;

namespace Portfolio.Application.Features.Projects.Commands.Create;

public class CreateProjectCommandValidator : AbstractValidator<CreateProjectCommandRequest>
{
    public CreateProjectCommandValidator()
    {
        RuleFor(p => p.UserId)
            .NotEmpty().WithMessage("UserId can not be Empty")
            .NotNull().WithMessage("UserId can not be null");
        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("Name can not be Empty")
            .NotNull().WithMessage("Name can not be null");
        RuleFor(p => p.Description)
            .NotEmpty().WithMessage("Description can not be Empty")
            .NotNull().WithMessage("Description can not be null");
        RuleFor(p => p.Link)
            .NotEmpty().WithMessage("Link can not be Empty")
            .NotNull().WithMessage("Link can not be null");
    }
}
