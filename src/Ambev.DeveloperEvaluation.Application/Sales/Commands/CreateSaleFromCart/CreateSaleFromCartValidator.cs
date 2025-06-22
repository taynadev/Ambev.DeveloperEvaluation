using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.Commands.CreateSaleFromCart
{
    /// <summary>
    /// Validates the CreateSaleFromCartCommand input values.
    /// </summary>
    public class CreateSaleFromCartValidator : AbstractValidator<CreateSaleFromCartCommand>
    {

        /// <summary>
        /// Initializes a new instance of the CreateSaleFromCartValidator with defined validation rules.
        /// </summary>
        /// <remarks>
        /// Validation rules include:
        /// - CartId: Required
        /// - BranchId: Required
        /// - BranchName: Required and maximum length of 100 characters.
        public CreateSaleFromCartValidator()
        {
            RuleFor(x => x.CartId).NotEmpty();
            RuleFor(x => x.BranchId).NotEmpty();
            RuleFor(x => x.BranchName).NotEmpty().MaximumLength(100);
        }
    }
}
