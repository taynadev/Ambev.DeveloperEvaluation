using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation;

public class CustomerValidator : AbstractValidator<Customer>
{
    public CustomerValidator()
    {
        RuleFor(c => c.Name)
            .NotEmpty().WithMessage("Customer name is required.")
            .MaximumLength(100).WithMessage("Customer name cannot exceed 100 characters.");

        RuleFor(c => c.DocumentNumber)
            .NotEmpty().WithMessage("Customer document is required.")
            .Length(11, 14).WithMessage("Customer document must be either 11 or 14 characters long.");

        RuleFor(c => c.Email)
            .EmailAddress().WithMessage("Invalid email format.")
            .When(c => !string.IsNullOrWhiteSpace(c.Email))
            .MaximumLength(100).WithMessage("Customer email cannot exceed 100 characters.");

        RuleFor(c => c.Phone).SetValidator(new PhoneValidator());
    }
}