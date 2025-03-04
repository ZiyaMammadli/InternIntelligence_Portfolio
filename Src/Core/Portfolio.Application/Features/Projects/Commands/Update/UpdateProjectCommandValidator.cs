using FluentValidation;

namespace Portfolio.Application.Features.Projects.Commands.Update;

public class UpdateProjectCommandValidator:AbstractValidator<DeleteProjectCommandRequest>
{
    public UpdateProjectCommandValidator()
    {
        RuleFor(u => u.Id)
            .NotEmpty().WithMessage("Id can not be Empty")
            .NotNull().WithMessage("Id can not be null");
        RuleFor(u => u.Name)
            .NotEmpty().WithMessage("Name can not be Empty")
            .NotNull().WithMessage("Name can not be null");
        RuleFor(u => u.Description)
            .NotEmpty().WithMessage("Description can not be Empty")
            .NotNull().WithMessage("Description can not be null");
        RuleFor(u => u.Link)
            .NotEmpty().WithMessage("Link can not be Empty")
            .NotNull().WithMessage("Link can not be null");
    }
}
