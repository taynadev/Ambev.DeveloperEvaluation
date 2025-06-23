using Ambev.DeveloperEvaluation.Common.Validation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Carts.Commands.CreateCartProduct
{
    /// <summary>
    /// Command to add a new item to a customer's cart.
    /// </summary>
    /// <remarks>
    /// This command contains the information needed to add a product to an existing cart.
    ///It implements <see cref="IRequest{TResponse}"/> to initiate the request 
    /// that returns a <see cref="AddCartProductResult"/>.
    /// 
    /// It is validated by <see cref="AddCartProductValidator"/> and handled by <see cref="AddCartProductHandler"/>.
    /// </remarks>
    public class AddCartProductCommand : IRequest<AddCartProductResult>
    {
        /// <summary>
        /// The identifier of the customer's cart.
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// The identifier of the product.
        /// </summary>
        public Guid ProductId { get; set; }

        /// <summary>
        /// The quantity to be added.
        /// </summary>
        public int Quantity { get; set; }

        public ValidationResultDetail Validate()
        {
            var validator = new AddCartProductValidator();
            var result = validator.Validate(this);
            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(e => (ValidationErrorDetail)e)
            };
        }
    }
}
