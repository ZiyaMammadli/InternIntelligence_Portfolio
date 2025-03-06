﻿using FluentValidation;

namespace Portfolio.Application.Features.Projects.Commands.Update;

public class UpdateProjectCommandValidator:AbstractValidator<UpdateProjectCommandRequest>
{
    public UpdateProjectCommandValidator()
    {
        RuleFor(p => p.Id)
            .NotEmpty().WithMessage("Id can not be Empty")
            .NotNull().WithMessage("Id can not be null");
        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("Name can not be Empty")
            .NotNull().WithMessage("Name can not be null")
            .MaximumLength(20).WithMessage("Maximum Lentgh must be 20");
        RuleFor(p => p.Description)
            .NotEmpty().WithMessage("Description can not be Empty")
            .NotNull().WithMessage("Description can not be null")
            .MaximumLength(100).WithMessage("Maximum Lentgh must be 100");
        RuleFor(p => p.Link)
            .NotEmpty().WithMessage("Link can not be Empty")
            .NotNull().WithMessage("Link can not be null")
            .MaximumLength(250).WithMessage("Maximum Lentgh must be 250");
    }
}
