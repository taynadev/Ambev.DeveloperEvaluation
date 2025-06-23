namespace Ambev.DeveloperEvaluation.Application.Sales.Commands.CreateSaleFromCart
{
    /// <summary>
    /// Result returned after successfully creating a sale.
    /// </summary>
    public class CreateSaleFromCartResult
    {
        /// <summary>
        /// The unique identifier of the created sale
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the user.
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// Gets or sets the name of the customer.
        /// </summary>
        public string CustomerName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the unique identifier for the branch.
        /// </summary>
        public Guid BranchId { get; set; }

        /// <summary>
        /// Gets or sets the name of the branch.
        /// </summary>
        public string BranchName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the collection of items to be included in the sale.
        /// </summary>
        public List<CreateSaleItemFromCartResultDto> Items { get; set; } = new();

    }

    /// <summary>
    /// Represents a result to create a new sale item in the system.
    /// </summary>
    public class CreateSaleItemFromCartResultDto
    {
        /// <summary>
        /// Gets or sets the unique identifier for the sale.
        /// </summary>
        public Guid ProductId { get; set; }

        /// <summary>
        /// Gets or sets the name of the sale.
        /// </summary>
        public string ProductName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the quantity of items.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>        /// 
        /// Gets or sets the unit price of the sale.
        /// </summary>
        public decimal UnitPrice { get; set; }
    }
}
