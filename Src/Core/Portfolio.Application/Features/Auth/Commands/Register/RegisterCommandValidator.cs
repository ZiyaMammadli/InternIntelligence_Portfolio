﻿using FluentValidation;

namespace Portfolio.Application.Features.Auth.Commands.Register;

public class RegisterCommandValidator:AbstractValidator<RegisterCommandRequest>
{
    public RegisterCommandValidator()
    {
        RuleFor(r => r.FirstName)
            .NotEmpty().WithMessage("FirstName can not be Empty")
            .NotNull().WithMessage("FirstName can not be null")
            .MaximumLength(20).WithMessage("Maximum Lentgh must be 20");
        RuleFor(r => r.LastName)
            .NotEmpty().WithMessage("LastName can not be Empty")
            .NotNull().WithMessage("LastName can not be null")
            .MaximumLength(50).WithMessage("Maximum Lentgh must be 50");
        RuleFor(r => r.UserName)
            .NotEmpty().WithMessage("UserName can not be Empty")
            .NotNull().WithMessage("UserName can not be null");
        RuleFor(r => r.Email)
            .EmailAddress().WithMessage("This are must be email")
            .NotEmpty().WithMessage("Email can not be Empty")
            .NotNull().WithMessage("Email can not be null");
        RuleFor(r => r.Password)
            .NotEmpty().WithMessage("Password can not be Empty")
            .NotNull().WithMessage("Password can not be null");
        RuleFor(r => r.ConfirmPassword)
            .NotEmpty().WithMessage("ConfirmPassword can not be Empty")
            .NotNull().WithMessage("ConfirmPassword can not be null")
            .Equal(r => r.Password).WithMessage("ConfirmPassword must be equal with Password");
    }
}
