using Ambev.DeveloperEvaluation.Common.Validation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Carts.Commands.CreateCart
{
    /// <summary>
    /// Command to create a new cart.
    /// </summary>
    /// <remarks>
    /// This command is responsible for initializing a cart with a customer and branch.
    ///  It implements <see cref="IRequest{TResponse}"/> to initiate the request 
    /// that returns a <see cref="CreateCartResult"/>.
    /// 
    /// The data provided in this command is validated using the 
    /// <see cref="CreateCartValidator"/> which extends 
    /// <see cref="AbstractValidator{T}"/> to ensure that the fields are correctly 
    /// populated and follow the required rules.
    /// </remarks>
    public class CreateCartCommand : IRequest<CreateCartResult>
    {
        /// <summary>
        /// The ID of the customer who owns the cart.
        /// </summary>
        public Guid CustomerId { get; set; }

        /// <summary>
        /// The name of the customer who owns the cart.
        /// </summary>
        public string CustomerName { get; set; }

        public ValidationResultDetail Validate()
        {
            var validator = new CreateCartValidator();
            var result = validator.Validate(this);
            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(e => (ValidationErrorDetail)e)
            };
        }
    }
}
