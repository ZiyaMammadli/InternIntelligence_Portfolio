using FluentValidation;

namespace Portfolio.Application.Features.ContactForms.Commands.SubmitForm;

public class SubmitFormCommandValidator:AbstractValidator<SubmitFormCommandRequest>
{
    public SubmitFormCommandValidator()
    {
        RuleFor(a => a.UserId)
          .NotEmpty().WithMessage("UserId can not be Empty")
          .NotNull().WithMessage("UserId can not be null");
        RuleFor(a => a.Name)
            .NotEmpty().WithMessage("Name can not be Empty")
            .NotNull().WithMessage("Name can not be null")
            .MaximumLength(20).WithMessage("Maximum Lentgh must be 20");
        RuleFor(a => a.Email)
            .NotEmpty().WithMessage("Email can not be Empty")
            .NotNull().WithMessage("Email can not be null")
            .EmailAddress().WithMessage("This are must be email")
            .MaximumLength(40).WithMessage("Maximum Lentgh must be 40");
        RuleFor(a => a.Message)
            .NotEmpty().WithMessage("Message can not be Empty")
            .NotNull().WithMessage("Message can not be null")
            .MaximumLength(100).WithMessage("Maximum Lentgh must be 100");
    }
}
