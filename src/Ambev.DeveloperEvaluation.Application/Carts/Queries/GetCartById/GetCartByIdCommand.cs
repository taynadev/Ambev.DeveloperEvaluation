using Ambev.DeveloperEvaluation.Common.Validation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Carts.Queries.GetCartById
{
    /// <summary>
    /// Query to retrieve a cart by its unique identifier.
    /// </summary>
    public class GetCartByIdCommand : IRequest<GetCartByIdResult>
    {
        /// <summary>
        /// The unique identifier of the cart.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Initializes a new instance of GetUserCommand
        /// </summary>
        /// <param name="id">The ID of the user to retrieve</param>
        public GetCartByIdCommand(Guid id)
        {
            Id = id;
        }


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