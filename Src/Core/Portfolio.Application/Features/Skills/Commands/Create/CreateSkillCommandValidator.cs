using FluentValidation;

namespace Portfolio.Application.Features.Skills.Commands.Create
{
    public class CreateSkillCommandValidator:AbstractValidator<CreateSkillCommandRequest>
    {
        public CreateSkillCommandValidator()
        {
            RuleFor(s => s.UserId)
                .NotEmpty().WithMessage("UserId can not be Empty")
                .NotNull().WithMessage("UserId can not be null");
            RuleFor(s => s.Name)
                .NotEmpty().WithMessage("Name can not be Empty")
                .NotNull().WithMessage("Name can not be null")
                .MaximumLength(20).WithMessage("Maximum Lentgh must be 20");
        }
    }
}
