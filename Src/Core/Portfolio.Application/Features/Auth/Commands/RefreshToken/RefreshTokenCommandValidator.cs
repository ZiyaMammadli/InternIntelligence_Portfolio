using FluentValidation;

namespace Portfolio.Application.Features.Auth.Commands.RefreshToken;

public class RefreshTokenCommandValidator:AbstractValidator<RefreshTokenCommandRequest>
{
    public RefreshTokenCommandValidator()
    {
        RuleFor(rt => rt.AccessToken)
            .NotEmpty().WithMessage("AccessToken can not be Empty")
            .NotNull().WithMessage("AccessToken can not be null");
        RuleFor(rt => rt.RefreshToken)
            .NotEmpty().WithMessage("RefreshToken can not be Empty")
            .NotNull().WithMessage("RefreshToken can not be null")
            .MaximumLength(200).WithMessage("Maximum Lentgh must be 200");
    }
}
