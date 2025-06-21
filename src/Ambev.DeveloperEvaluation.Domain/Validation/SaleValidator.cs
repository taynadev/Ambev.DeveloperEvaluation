using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation;

public class SaleValidator : AbstractValidator<Sale>
{
    public SaleValidator()
    {
        RuleFor(sale => sale.SaleNumber)
           .NotEmpty().WithMessage("Sale number must be provided.")
           .MaximumLength(50).WithMessage("Sale number cannot exceed 50 characters.");

        RuleFor(sale => sale.SaleDate)
            .NotEmpty().WithMessage("Sale date must be provided.")
            .LessThanOrEqualTo(DateTime.UtcNow).WithMessage("Sale date cannot be in the future.");

        RuleFor(sale => sale.CustomerId)
            .NotEmpty().WithMessage("Customer ID must be provided.");

        RuleFor(sale => sale.CustomerName)
            .NotEmpty().WithMessage("Customer name must be provided.")
            .MaximumLength(100).WithMessage("Customer name cannot exceed 100 characters.");

        RuleFor(sale => sale.BranchId)
            .NotEmpty().WithMessage("Branch ID must be provided.");

        RuleFor(sale => sale.BranchName)
            .NotEmpty().WithMessage("Branch name must be provided.")
            .MaximumLength(100).WithMessage("Branch name cannot exceed 100 characters.");

        RuleFor(x => x.Items)
            .NotEmpty().WithMessage("Items cannot be empty")
            .Must(items => items != null && items.Count != 0).WithMessage("Sale must contain at least one item")
            .ForEach(item => item.SetValidator(new SaleItemValidator()));
    }
}
