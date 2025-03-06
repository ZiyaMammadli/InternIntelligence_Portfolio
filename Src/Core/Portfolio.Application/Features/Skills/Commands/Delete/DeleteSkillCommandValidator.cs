using FluentValidation;

namespace Portfolio.Application.Features.Skills.Commands.Delete;

public class DeleteSkillCommandValidator:AbstractValidator<DeleteSkillCommandRequest>
{
    public DeleteSkillCommandValidator()
    {
        RuleFor(s => s.Id)
          .NotEmpty().WithMessage("Id can not be Empty")
          .NotNull().WithMessage("Id can not be null");
    }
}
