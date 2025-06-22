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
    }
}