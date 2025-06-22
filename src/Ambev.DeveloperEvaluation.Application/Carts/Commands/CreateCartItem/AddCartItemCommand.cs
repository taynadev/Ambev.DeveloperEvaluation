using Ambev.DeveloperEvaluation.Common.Validation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Carts.Commands.CreateCartItem
{
    /// <summary>
    /// Command to add a new item to a customer's cart.
    /// </summary>
    /// <remarks>
    /// This command contains the information needed to add a product to an existing cart.
    ///It implements <see cref="IRequest{TResponse}"/> to initiate the request 
    /// that returns a <see cref="AddCartItemResult"/>.
    /// 
    /// It is validated by <see cref="AddCartItemValidator"/> and handled by <see cref="AddCartItemHandler"/>.
    /// </remarks>
    public class AddCartItemCommand : IRequest<AddCartItemResult>
    {
        /// <summary>
        /// The identifier of the cart.
        /// </summary>
        public Guid CartId { get; set; }

        /// <summary>
        /// The identifier of the product.
        /// </summary>
        public Guid ProductId { get; set; }

        /// <summary>
        /// The name of the product.
        /// </summary>
        public string ProductName { get; set; } = string.Empty;

        /// <summary>
        /// The quantity to be added.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// The unit price of the product.
        /// </summary>
        public decimal UnitPrice { get; set; }

        public ValidationResultDetail Validate()
        {
            var validator = new AddCartItemValidator();
            var result = validator.Validate(this);
            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(e => (ValidationErrorDetail)e)
            };
        }
    }
}
