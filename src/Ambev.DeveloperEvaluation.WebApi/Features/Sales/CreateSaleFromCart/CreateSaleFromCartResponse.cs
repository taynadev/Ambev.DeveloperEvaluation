namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;

/// <summary>
/// API response model for CreateSale operation
/// </summary>
public class CreateSaleFromCartResponse
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
    public List<CreateSaleItemFromCartResponseDto> Items { get; set; } = new();
}

/// <summary>
/// Represents a response to create a new sale item in the system.
/// </summary>
public class CreateSaleItemFromCartResponseDto
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
