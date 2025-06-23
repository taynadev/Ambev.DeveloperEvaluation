namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.CreateCart
{
    /// <summary>
    /// Represents a request to create a new cart.
    /// </summary>
    public class CreateCartRequest
    {
        /// <summary>
        /// The customer identifier
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// The creation date of the cart.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// The list of products in the cart.
        /// </summary>
        public List<CreateCartProductRequest> Products { get; set; } = [];
    }

    /// <summary>
    /// Represents a product item within a CreateCartRequest.
    /// </summary>
    public class CreateCartProductRequest
    {
        /// <summary>
        /// Gets or sets the ID of the product.
        /// </summary>
        public Guid ProductId { get; set; }

        /// <summary>
        /// Gets or sets the quantity of the product.
        /// </summary>
        public int Quantity { get; set; }
    }
}
