using Ambev.DeveloperEvaluation.Common.Validation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Carts.Commands.RemoveCartProduct
{
    /// <summary>
    /// Command to remove an item from a customer's cart.
    /// </summary>
    /// <remarks>
    /// This command removes a specific item from a cart using the cart ID and item ID.
    /// It implements <see cref="IRequest{TResponse}"/> to initiate the request 
    /// that returns a <see cref="RemoveCartProductResult"/>.
    /// 
    /// It is validated by <see cref="RemoveCartProductValidator"/> and handled by <see cref="RemoveCartProductHandler"/>.
    /// </remarks>
    /// </remarks>
    public class RemoveCartProductCommand : IRequest<RemoveCartProductResult>
    {
        /// <summary>
        /// The ID of the cart from which the item will be removed.
        /// </summary>
        public Guid CartId { get; set; }

        /// <summary>
        /// The ID of the item to be removed.
        /// </summary>
        public Guid ItemId { get; set; }

        public ValidationResultDetail Validate()
        {
            var validator = new RemoveCartProductValidator();
            var result = validator.Validate(this);
            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
            };
        }
    }
}
