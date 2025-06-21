using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation;

public class PhoneValidator : AbstractValidator<string>
{
    public PhoneValidator()
    {
        RuleFor(phone => phone)
            .NotEmpty()
            .WithMessage("The phone cannot be empty.")
            .Matches(@"^\+[1-9]\d{10,14}$")
            .WithMessage("Phone number must start with '+' followed by 11-15 digits.");
    }
}
