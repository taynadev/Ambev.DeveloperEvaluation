using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;

/// <summary>
/// Validator for CreateSaleRequest that defines validation rules for sale creation.
/// </summary>
public class CreateSaleFromCartRequestValidator : AbstractValidator<CreateSaleFromCartRequest>
{
    /// <summary>
    /// Initializes a new instance of the CreateSaleFromCartRequestValidator with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - CartId: Required
    /// - BranchId: Required
    /// - BranchName: Required and length limited to 100 characters
    /// </remarks>
    public CreateSaleFromCartRequestValidator()
    {
        RuleFor(x => x.CartId).NotEmpty();
        RuleFor(x => x.BranchId).NotEmpty();
        RuleFor(x => x.BranchName).NotEmpty().MaximumLength(100);
    }
}