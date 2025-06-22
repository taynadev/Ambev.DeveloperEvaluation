using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Carts.Commands.RemoveCartItem
{
    /// <summary>
    /// Validator for <see cref="RemoveCartItemCommand"/> defining rules to validate the command.
    /// </summary>
    public class RemoveCartItemValidator : AbstractValidator<RemoveCartItemCommand>
    {
        /// <summary>
        /// Initializes a new instance of the RemoveCartItemValidator with defined validation rules.
        /// </summary>
        /// <remarks>
        /// Validation rules include:
        ///
        ///  - CartId: Required
        ///  - ItemId: Required
        public RemoveCartItemValidator()
        {
            RuleFor(c => c.CartId).NotEmpty().WithMessage("CartId is required.");
            RuleFor(c => c.ItemId).NotEmpty().WithMessage("ItemId is required.");
        }
    }
}