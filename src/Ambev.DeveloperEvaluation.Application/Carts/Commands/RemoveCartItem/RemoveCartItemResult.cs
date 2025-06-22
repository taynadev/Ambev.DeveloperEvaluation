namespace Ambev.DeveloperEvaluation.Application.Carts.Commands.RemoveCartItem
{
    /// <summary>
    /// Response returned after successfully removing an item from the cart.
    /// </summary>
    public class RemoveCartItemResult
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