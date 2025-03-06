﻿using FluentValidation;

namespace Portfolio.Application.Features.Achievements.Commands.Create;

public class CreateAchievementCommandValidator:AbstractValidator<CreateAchievementCommandRequest>
{
    public CreateAchievementCommandValidator()
    {
        RuleFor(a => a.UserId)
           .NotEmpty().WithMessage("UserId can not be Empty")
           .NotNull().WithMessage("UserId can not be null");
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
