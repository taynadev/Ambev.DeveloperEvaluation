using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation;

public class CartValidator : AbstractValidator<Cart>
{
    public CartValidator()
    {
        RuleFor(c => c.CustomerId)
            .NotEmpty().WithMessage("CustomerId is required.");

        RuleFor(c => c.CustomerName)
            .NotEmpty().WithMessage("CustomerName is required.")
            .MaximumLength(100).WithMessage("CustomerName cannot exceed 100 characters.");

        RuleForEach(c => c.Items)
            .SetValidator(new CartItemValidator());
    }
}