namespace Ambev.DeveloperEvaluation.Application.Carts.Commands.ClearCart
{
    /// <summary>
    /// Response returned after successfully clearing the cart.
    /// </summary>
    public class ClearCartResult
    {
        /// <summary>
        /// The identifier of the cart that was cleared.
        /// </summary>
        public Guid CartId { get; set; }

        /// <summary>
        /// The total amount of the cart after clearing (should be zero).
        /// </summary>
        public decimal TotalAmount { get; set; }

        /// <summary>
        /// The total amount with discounts after clearing (should be zero).
        /// </summary>
        public decimal TotalAmountWithDiscount { get; set; }
    }
}