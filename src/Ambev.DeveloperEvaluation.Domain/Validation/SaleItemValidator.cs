using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation;

public class SaleItemValidator : AbstractValidator<SaleItem>
{
    public SaleItemValidator()
    {
        RuleFor(item => item.ProductId)
            .NotEmpty().WithMessage("Product ID must be provided.");

        RuleFor(item => item.ProductName)
            .NotEmpty().WithMessage("Product name must be provided.")
            .MaximumLength(100).WithMessage("Product name cannot exceed 100 characters.");
    }
}
