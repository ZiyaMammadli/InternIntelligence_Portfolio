using FluentValidation;

namespace Portfolio.Application.Features.Skills.Commands.Update;

public class UpdateSkillCommandValidator:AbstractValidator<UpdateSkillCommandRequest>
{
    public UpdateSkillCommandValidator()
    {
        RuleFor(s => s.Id)
          .NotEmpty().WithMessage("Id can not be Empty")
          .NotNull().WithMessage("Id can not be null");
        RuleFor(s => s.Name)
            .NotEmpty().WithMessage("Name can not be Empty")
            .NotNull().WithMessage("Name can not be null");
    }
}
