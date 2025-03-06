using FluentValidation;

namespace Portfolio.Application.Features.Achievements.Commands.Update;

public class UpdateAchievementCommandValidator:AbstractValidator<UpdateAchievementCommandRequest>
{
    public UpdateAchievementCommandValidator()
    {
        RuleFor(a => a.Id)
           .NotEmpty().WithMessage("Id can not be Empty")
           .NotNull().WithMessage("Id can not be null");
        RuleFor(a => a.Name)
            .NotEmpty().WithMessage("Name can not be Empty")
            .NotNull().WithMessage("Name can not be null")
            .MaximumLength(40).WithMessage("Maximum Lentgh must be 40");
        RuleFor(a => a.Description)
            .NotEmpty().WithMessage("Description can not be Empty")
            .NotNull().WithMessage("Description can not be null")
            .MaximumLength(100).WithMessage("Maximum Lentgh must be 100");
        RuleFor(a => a.AchievementDate)
            .NotEmpty().WithMessage("AchievementDate can not be Empty")
            .NotNull().WithMessage("AchievementDate can not be null");
    }
}
