namespace Ambev.DeveloperEvaluation.Application.Carts.Commands.CreateCart
{
    /// <summary>
    /// Represents the response returned after successfully creating a cart.
    /// </summary>
    public class CreateCartResult
    {
        /// <summary>
        /// Gets or sets the unique identifier of the created cart.
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Gets or sets the customer identifier.
        /// </summary>
        public Guid CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the creation date of the cart.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        public List<CartProductResultDto> Products { get; set; } = [];
    }

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
    public class CartProductResultDto
    {

        /// <summary>
        /// The identifier of the product.
        /// </summary>
        public Guid ProductId { get; set; }

        /// <summary>
        /// The quantity to be added.
        /// </summary>
        public int Quantity { get; set; }
    }
}