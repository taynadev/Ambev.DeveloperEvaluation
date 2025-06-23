namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.CreateCart
{
    /// <summary>
    /// API response model for the CreateCart operation.
    /// </summary>
    public class CreateCartResponse
    {
        /// <summary>
        /// Gets or sets the cart identifier.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the user identifier (customer).
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// Gets or sets the creation date of the cart.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Gets or sets the list of products added to the cart.
        /// </summary>
        public List<CreateCartProductesponse> Products { get; set; } = [];
    }

    /// <summary>
    /// Represents a product item returned in the CreateCartResponse.
    /// </summary>
    public class CreateCartProductesponse
    {
        /// <summary>
        /// Gets or sets the ID of the product.
        /// </summary>
        public Guid ProductId { get; set; }

        /// <summary>
        /// Gets or sets the quantity of the product in the cart.
        /// </summary>
        public int Quantity { get; set; }
    }
}
