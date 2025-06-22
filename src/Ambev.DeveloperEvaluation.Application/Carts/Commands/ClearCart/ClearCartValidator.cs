using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Carts.Commands.ClearCart
{
    /// <summary>
    /// Validator for <see cref="ClearCartCommand"/>, ensuring a valid CartId is provided.
    /// </summary>
    public class ClearCartValidator : AbstractValidator<ClearCartCommand>
    {
        /// <summary>
        /// Initializes a new instance of the ClearCartValidator with defined validation rules.
        /// </summary>
        /// <remarks>
        /// Validation rules include:
        ///
        ///  - CartId: Required
        public ClearCartValidator()
        {
            RuleFor(x => x.CartId).NotEmpty().WithMessage("CartId is required.");
        }
    }
}
