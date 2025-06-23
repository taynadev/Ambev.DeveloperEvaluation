using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.Commands.CancelSale
{
    /// <summary>
    /// Validator for <see cref="CancelSaleCommand"/>.
    /// </summary>
    public class CancelSaleValidator : AbstractValidator<CancelSaleCommand>
    {
        /// <summary>
        /// Constructor that initializes the validation rules for the CancelSaleCommand.
        /// Validation rules include:
        /// - SaleId: Required
        public CancelSaleValidator()
        {
            RuleFor(x => x.SaleId).NotEmpty().WithMessage("Sale ID must be provided.");
        }
    }
}
