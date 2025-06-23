using Ambev.DeveloperEvaluation.Common.Validation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.Commands.CreateSaleFromCart
{
    /// <summary>
    /// Command to create a new sale based on an existing cart.
    /// </summary>
    /// <remarks>
    /// Requires the cart ID and branch details to generate the sale.
    /// </remarks>
    public class CreateSaleFromCartCommand : IRequest<CreateSaleFromCartResult>
    {
        /// <summary>
        /// Gets or sets the cart ID to convert into a sale.
        /// </summary>
        public Guid CartId { get; set; }

        /// <summary>
        /// Gets or sets the branch ID where the sale is taking place.
        /// </summary>
        public Guid BranchId { get; set; }

        /// <summary>
        /// Gets or sets the branch name.
        /// </summary>
        public string BranchName { get; set; } = string.Empty;

        /// <summary>
        /// Validates the command using CreateSaleFromCartCommandValidator.
        /// </summary>
        public ValidationResultDetail Validate()
        {
            var validator = new CreateSaleFromCartValidator();
            var result = validator.Validate(this);
            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(e => (ValidationErrorDetail)e)
            };
        }
    }
}
