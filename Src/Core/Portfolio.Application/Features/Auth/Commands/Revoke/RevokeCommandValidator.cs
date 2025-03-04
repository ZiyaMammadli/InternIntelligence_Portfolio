using FluentValidation;

namespace Portfolio.Application.Features.Auth.Commands.Revoke;

public class RevokeCommandValidator:AbstractValidator<RevokeCommandRequest>
{
    public RevokeCommandValidator()
    {
        RuleFor(r => r.Email)
            .EmailAddress().WithMessage("This are must be email")
            .NotEmpty().WithMessage("Email can not be Empty")
            .NotNull().WithMessage("Email can not be null");
    }
}
