namespace Ambev.DeveloperEvaluation.Application.Carts.Queries.GetCartById
{
    /// <summary>
    /// DTO containing cart information returned by <see cref="GetCartByIdQuery"/>.
    /// </summary>
    public class GetCartByIdResult
    {
        /// <summary>
        /// The ID of the cart.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The ID of the customer that owns this cart.
        /// </summary>
        public Guid CustomerId { get; set; }

        /// <summary>
        /// Tthe creation timestamp of the cart.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// The total amount of all items in the cart (without discounts).
        /// </summary>
        public decimal TotalAmount { get; set; }

        /// <summary>
        /// The total amount of all items in the cart including discounts.
        /// </summary>
        public decimal TotalAmountWithDiscount { get; set; }

        /// <summary>
        /// The list of items currently in the cart.
        /// </summary>
        public List<GetCartItemResult> Items { get; set; } = [];
    }

    /// <summary>
    /// DTO containing information about a single item in a cart.
    /// </summary>
    public class GetCartItemResult
    {
        /// <summary>
        /// The ID of the cart item.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The product ID of the item in the cart.
        /// </summary>
        public Guid ProductId { get; set; }

        /// <summary>
        /// The product name of the item in the cart.
        /// </summary>
        public string ProductName { get; set; } = string.Empty;

        /// <summary>
        /// the quantity of the product.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// The unit price of the product.
        /// </summary>
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// The total amount without discount.
        /// </summary>
        public decimal TotalAmount { get; set; }

        /// <summary>
        /// The the amount discounted.
        /// </summary>
        public decimal DiscountAmount { get; set; }

        /// <summary>
        /// The total price with discount applied.
        /// </summary>
        public decimal TotalAmountWithDiscount { get; set; }
    }
}