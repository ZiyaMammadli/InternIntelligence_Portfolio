﻿using FluentValidation;

namespace Portfolio.Application.Features.Auth.Commands.Login;

public class LoginCommandValidation:AbstractValidator<LoginCommandRequest>
{
    public LoginCommandValidation()
    {
        RuleFor(l => l.Email)
            .EmailAddress().WithMessage("This are must be email")
            .NotEmpty().WithMessage("Email can not be Empty")
            .NotNull().WithMessage("Email can not be null");
        RuleFor(l => l.Password)
            .NotEmpty().WithMessage("Password can not be Empty")
            .NotNull().WithMessage("Password can not be null");
    }
}
