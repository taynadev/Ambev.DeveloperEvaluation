namespace Ambev.DeveloperEvaluation.Application.Carts.Queries.GetCart
{
    /// <summary>
    /// DTO containing cart information returned by <see cref="GetCartsCommand"/>.
    /// </summary>
    public class GetCartsResult
    {
        /// <summary>
        /// Current page number.
        /// </summary>
        public int CurrentPage { get; set; }

        /// <summary>
        /// Total number of items.
        /// </summary>
        public int TotalItems { get; set; }

        /// <summary>
        /// Total number of pages.
        /// </summary>
        public int TotalPages { get; set; }

        /// <summary>
        /// List of carts.
        /// </summary>
        public List<CartDto> Data { get; set; } = [];
    }

    /// <summary>
    /// DTO representing a cart with its items.
    /// </summary>
    public class CartDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public DateTime Date { get; set; }
        public List<CartProductDto> Products { get; set; } = [];
    }

    /// <summary>
    /// DTO representing a product inside a cart.
    /// </summary>
    public class CartProductDto
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}