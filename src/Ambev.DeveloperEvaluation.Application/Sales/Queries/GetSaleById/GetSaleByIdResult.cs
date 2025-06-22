namespace Ambev.DeveloperEvaluation.Application.Sales.Queries.GetSaleById
{
    /// <summary>
    /// Represents the detailed result of a sale queried by ID.
    /// </summary>
    /// <remarks>
    /// Contains all relevant information about a sale, including metadata,
    /// customer and branch data, cancellation status, and itemized product details.
    /// </remarks>
    public class GetSaleByIdResult
    {
        /// <summary>
        /// Gets or sets the unique identifier of the sale.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the unique number assigned to the sale.
        /// </summary>
        public long SaleNumber { get; set; }

        /// <summary>
        /// Gets or sets the date and time the sale was created.
        /// </summary>
        public DateTime SaleDate { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the customer.
        /// </summary>
        public Guid CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the denormalized name of the customer.
        /// </summary>
        public string CustomerName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the unique identifier of the branch where the sale occurred.
        /// </summary>
        public Guid BranchId { get; set; }

        /// <summary>
        /// Gets or sets the denormalized name of the branch.
        /// </summary>
        public string BranchName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets a value indicating whether the entire sale was canceled.
        /// </summary>
        public bool IsCanceled { get; set; }

        /// <summary>
        /// Gets or sets the total amount of the sale without discounts, ignoring canceled items.
        /// </summary>
        public decimal TotalAmount { get; set; }

        /// <summary>
        /// Gets or sets the total amount of the sale with discounts applied, ignoring canceled items.
        /// </summary>
        public decimal TotalAmountWithDiscount { get; set; }

        /// <summary>
        /// Gets or sets the list of items included in the sale.
        /// </summary>
        public List<SaleItemDto> Items { get; set; } = [];
    }

    /// <summary>
    /// Represents a single item included in a sale transaction.
    /// </summary>
    /// <remarks>
    /// Each item includes quantity, unit price, discounts, and cancellation status.
    /// </remarks>
    public class SaleItemDto
    {
        /// <summary>
        /// Gets or sets the unique identifier of the item in the sale.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the product sold.
        /// </summary>
        public Guid ProductId { get; set; }

        /// <summary>
        /// Gets or sets the name of the product sold (denormalized).
        /// </summary>
        public string ProductName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the quantity of the product sold.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets the unit price of the product at the time of sale.
        /// </summary>
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// Gets or sets the total amount for the item (unit price × quantity).
        /// </summary>
        public decimal TotalAmount { get; set; }

        /// <summary>
        /// Gets or sets the discount percentage applied to the item based on quantity.
        /// </summary>
        public decimal DiscountPercentage { get; set; }

        /// <summary>
        /// Gets or sets the discount amount subtracted from the total.
        /// </summary>
        public decimal DiscountAmount { get; set; }

        /// <summary>
        /// Gets or sets the final amount charged after applying discounts.
        /// </summary>
        public decimal TotalAmountWithDiscount { get; set; }

        /// <summary>
        /// Gets or sets whether the item was canceled.
        /// </summary>
        public bool IsCanceled { get; set; }
    }
}
