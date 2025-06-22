using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation;

public class CartValidator : AbstractValidator<Cart>
{
    public CartValidator()
    {
        RuleFor(c => c.CustomerId)
            .NotEmpty().WithMessage("CustomerId is required.");

        RuleFor(c => c.CustomerId)
            .NotEmpty().WithMessage("Customer id is required.");

        RuleForEach(c => c.Items)
            .SetValidator(new CartItemValidator());
    }
}