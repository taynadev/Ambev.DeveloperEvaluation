using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.CreateCart
{
    /// <summary>
    /// Validator for CreateCartRequest that defines rules for cart creation.
    /// </summary>
    /// <remarks>
    /// - UserId must be a valid Guid.
    /// - Date must be present.
    /// - Each product must follow the rules of CreateCartProductRequestValidator.
    /// </remarks>
    public class CreateCartRequestValidator : AbstractValidator<CreateCartRequest>
    {
        public CreateCartRequestValidator()
        {
            RuleForEach(x => x.Products).SetValidator(new CreateCartProductRequestValidator());
        }
    }

    /// <summary>
    /// Validator for CreateCartProductRequest that defines rules for product items in the cart.
    /// </summary>
    /// <remarks>
    /// - ProductId must be a valid Guid.
    /// - Quantity must be greater than 0.
    /// </remarks>
    public class CreateCartProductRequestValidator : AbstractValidator<CreateCartProductRequest>
    {
        public CreateCartProductRequestValidator()
        {
            RuleFor(x => x.ProductId).NotEmpty().WithMessage("ProductId is required.");
            RuleFor(x => x.Quantity).GreaterThan(0).WithMessage("Quantity must be greater than zero.");
        }
    }
}
