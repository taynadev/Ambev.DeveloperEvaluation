using Ambev.DeveloperEvaluation.Common.Validation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Carts.Commands.RemoveCartItem
{
    /// <summary>
    /// Command to remove an item from a customer's cart.
    /// </summary>
    /// <remarks>
    /// This command removes a specific item from a cart using the cart ID and item ID.
    /// It implements <see cref="IRequest{TResponse}"/> to initiate the request 
    /// that returns a <see cref="RemoveCartItemResult"/>.
    /// 
    /// It is validated by <see cref="RemoveCartItemValidator"/> and handled by <see cref="RemoveCartItemHandler"/>.
    /// </remarks>
    /// </remarks>
    public class RemoveCartItemCommand : IRequest<RemoveCartItemResult>
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
            var validator = new RemoveCartItemValidator();
            var result = validator.Validate(this);
            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
            };
        }
    }
}
