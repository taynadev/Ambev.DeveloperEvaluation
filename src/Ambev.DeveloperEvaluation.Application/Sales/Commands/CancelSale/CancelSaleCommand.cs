using Ambev.DeveloperEvaluation.Common.Validation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.Commands.CancelSale
{
    /// <summary>
    /// Command for cancelling an existing sale.
    /// </summary>
    /// <remarks>
    /// Requires the sale ID to cancel the corresponding sale and its items.
    /// </remarks>
    public class CancelSaleCommand : IRequest<CancelSaleResult>
    {
        /// <summary>
        /// Gets or sets the ID of the sale to be canceled.
        /// </summary>
        public Guid SaleId { get; set; }

        /// <summary>
        /// Validates the command using <see cref="CancelSaleValidator"/>.
        /// </summary>
        public ValidationResultDetail Validate()
        {
            var validator = new CancelSaleValidator();
            var result = validator.Validate(this);
            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
            };
        }
    }

}
