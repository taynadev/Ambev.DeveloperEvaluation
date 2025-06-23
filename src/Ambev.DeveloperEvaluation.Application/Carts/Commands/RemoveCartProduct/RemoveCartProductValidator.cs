using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Carts.Commands.RemoveCartProduct
{
    /// <summary>
    /// Validator for <see cref="RemoveCartProductCommand"/> defining rules to validate the command.
    /// </summary>
    public class RemoveCartProductValidator : AbstractValidator<RemoveCartProductCommand>
    {
        /// <summary>
        /// Initializes a new instance of the RemoveCartProductValidator with defined validation rules.
        /// </summary>
        /// <remarks>
        /// Validation rules include:
        ///
        ///  - CartId: Required
        ///  - ItemId: Required
        public RemoveCartProductValidator()
        {
            RuleFor(c => c.CartId).NotEmpty().WithMessage("CartId is required.");
            RuleFor(c => c.ItemId).NotEmpty().WithMessage("ItemId is required.");
        }
    }
}