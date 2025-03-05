using FluentValidation;

namespace Portfolio.Application.Features.Achievements.Commands.Delete;

public class DeleteAchievementCommandValidator:AbstractValidator<DeleteAchievementCommandRequest>
{
    public DeleteAchievementCommandValidator()
    {
        RuleFor(a => a.Id)
           .NotEmpty().WithMessage("Id can not be Empty")
           .NotNull().WithMessage("Id can not be null");
    }
}
