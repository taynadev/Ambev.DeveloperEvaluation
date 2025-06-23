using Ambev.DeveloperEvaluation.Common.Validation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Carts.Commands.ClearCart
{
    /// <summary>
    /// Command to clear all items from a customer's cart.
    /// </summary>
    /// <remarks>
    /// This command removes all items from a specific cart identified by its ID.
    /// It implements <see cref="IRequest{TResponse}"/> to initiate the request 
    /// that returns a <see cref="ClearCartResult"/>.
    /// 
    /// The data provided in this command is validated using the 
    /// <see cref="ClearCartValidator"/> which extends 
    /// <see cref="AbstractValidator{T}"/> to ensure that the fields are correctly 
    /// populated and follow the required rules.
    /// </remarks>
    public class ClearCartCommand : IRequest<ClearCartResult>
    {
        /// <summary>
        /// The unique identifier of the cart to be cleared.
        /// </summary>
        public Guid CartId { get; set; }

        public ValidationResultDetail Validate()
        {
            var validator = new ClearCartValidator();
            var result = validator.Validate(this);
            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
            };
        }
    }
}
