namespace Ambev.DeveloperEvaluation.Application.Carts.Commands.CreateCartItem
{
    /// <summary>
    /// Response returned after successfully adding an item to the cart.
    /// </summary>
    public class AddCartItemResult
    {
        /// <summary>
        /// The identifier of the updated cart.
        /// </summary>
        public Guid CartId { get; set; }

        /// <summary>
        /// The total amount of the cart before discounts.
        /// </summary>
        public decimal TotalAmount { get; set; }

        /// <summary>
        /// The total amount of the cart after applying discounts.
        /// </summary>
        public decimal TotalAmountWithDiscount { get; set; }
    }
}