using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Carts.Commands.CreateCartProduct
{
    /// <summary>
    /// Validator for <see cref="AddCartProductCommand"/> defining rules for adding cart items.
    /// </summary>
    public class AddCartProductValidator : AbstractValidator<AddCartProductCommand>
    {
        /// <summary>
        /// Initializes a new instance of the AddCartProductValidator with defined validation rules.
        /// </summary>
        /// <remarks>
        /// Validation rules include:        ///
        ///  - ProductId: Required
        ///  - Quantity: Required and limits the quantity to be between 1 and 20.
        public AddCartProductValidator()
        {
            RuleFor(c => c.ProductId).NotEmpty();
            RuleFor(c => c.Quantity).GreaterThan(0).WithMessage("Quantity must be greater than zero.")
                .LessThanOrEqualTo(20).WithMessage("Cannot add more than 20 units of a product.");
        }
    }
}
