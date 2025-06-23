namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;

/// <summary>
/// Represents a request to create a new sale in the system.
/// </summary>
public class CreateSaleRequest
{
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
    public List<CreateSaleItemRequestDto> Items { get; set; } = new();
}

/// <summary>
/// Represents a request to create a new sale item in the system.
/// </summary>
public class CreateSaleItemRequestDto
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