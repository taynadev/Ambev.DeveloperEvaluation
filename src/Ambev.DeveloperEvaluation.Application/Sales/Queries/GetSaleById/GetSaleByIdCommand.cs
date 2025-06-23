using Ambev.DeveloperEvaluation.Common.Validation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.Queries.GetSaleById
{
    /// <summary>
    /// Query to retrieve a specific sale by its unique identifier.
    /// </summary>
    public class GetSaleByIdCommand : IRequest<GetSaleByIdResult>
    {
        /// <summary>
        /// Gets or sets the ID of the sale to retrieve.
        /// </summary>
        public Guid SaleId { get; set; }

        public GetSaleByIdCommand(Guid saleId)
        {
            SaleId = saleId;
        }

        /// <summary>
        /// Validates the query using <see cref="GetSaleByIdValidator"/>.
        /// </summary>
        public ValidationResultDetail Validate()
        {
            var validator = new GetSaleByIdValidator();
            var result = validator.Validate(this);
            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(e => (ValidationErrorDetail)e)
            };
        }
    }
}
