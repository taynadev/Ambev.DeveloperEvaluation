using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Carts.Commands.CreateCartItem
{
    /// <summary>
    /// Validator for <see cref="AddCartItemCommand"/> defining rules for adding cart items.
    /// </summary>
    public class AddCartItemValidator : AbstractValidator<AddCartItemCommand>
    {
        /// <summary>
        /// Initializes a new instance of the AddCartItemValidator with defined validation rules.
        /// </summary>
        /// <remarks>
        /// Validation rules include:        ///
        ///  - ProductId: Required
        ///  - ProductName: Required
        ///  - Quantity: Required and limits the quantity to be between 1 and 20.
        public AddCartItemValidator()
        {
            RuleFor(c => c.ProductId).NotEmpty();
            RuleFor(c => c.ProductName).NotEmpty().MaximumLength(100);
            RuleFor(c => c.Quantity).GreaterThan(0).WithMessage("Quantity must be greater than zero.")
                .LessThanOrEqualTo(20).WithMessage("Cannot add more than 20 units of a product.");
        }
    }
}
