using Ambev.DeveloperEvaluation.Common.Validation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.Queries.GetProductById
{
    /// <summary>
    /// Query to retrieve a specific product by its unique identifier.
    /// </summary>
    public class GetProductByIdCommand : IRequest<GetProductByIdResult>
    {
        /// <summary>
        /// Gets or sets the ID of the product to retrieve.
        /// </summary>
        public Guid Id { get; set; }

        public GetProductByIdCommand(Guid productId)
        {
            Id = productId;
        }

        /// <summary>
        /// Validates the query using <see cref="GetProductByIdValidator"/>.
        /// </summary>
        public ValidationResultDetail Validate()
        {
            var validator = new GetProductByIdValidator();
            var result = validator.Validate(this);
            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(e => (ValidationErrorDetail)e)
            };
        }
    }
}
