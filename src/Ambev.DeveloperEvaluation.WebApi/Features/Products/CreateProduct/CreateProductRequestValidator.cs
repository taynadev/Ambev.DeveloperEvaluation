using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProduct;

/// <summary>
/// Validator for CreateProductRequest that defines validation rules for product creation.
/// </summary>
public class CreateProductRequestValidator : AbstractValidator<CreateProductRequest>
{
    /// <summary>
    /// Initializes a new instance of the CreateProductRequestValidator with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - Title must not be empty and must not exceed 100 characters.
    /// - Description must not exceed 500 characters if provided.
    /// </remarks>
    public CreateProductRequestValidator()
    {
        RuleFor(p => p.Title)
                .NotEmpty().WithMessage("Product title is required.")
                .MaximumLength(100).WithMessage("Product title must not exceed 100 characters.");

        RuleFor(p => p.Description)
            .MaximumLength(500).WithMessage("Description must not exceed 500 characters.")
            .When(p => !string.IsNullOrEmpty(p.Description));
    }
}