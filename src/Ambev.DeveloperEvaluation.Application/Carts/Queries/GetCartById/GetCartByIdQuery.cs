using Ambev.DeveloperEvaluation.Common.Validation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Carts.Queries.GetCartById
{
    /// <summary>
    /// Query to retrieve a cart by its unique identifier.
    /// </summary>
    public class GetCartByIdQuery : IRequest<GetCartByIdResult>
    {
        /// <summary>
        /// The unique identifier of the cart.
        /// </summary>
        public Guid CartId { get; set; }

        public ValidationResultDetail Validate()
        {
            var validator = new GetCartByIdQueryValidator();
            var result = validator.Validate(this);
            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
            };
        }
    }
}