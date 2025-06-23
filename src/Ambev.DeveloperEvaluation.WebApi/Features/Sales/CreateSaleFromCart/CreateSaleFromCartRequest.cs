namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;

/// <summary>
/// Represents a request to create a new sale in the system.
/// </summary>
public class CreateSaleFromCartRequest
{
    /// <summary>
    /// Gets or sets the cart ID to convert into a sale.
    /// </summary>
    public Guid CartId { get; set; }

    /// <summary>
    /// Gets or sets the branch ID where the sale is taking place.
    /// </summary>
    public Guid BranchId { get; set; }

    /// <summary>
    /// Gets or sets the branch name.
    /// </summary>
    public string BranchName { get; set; } = string.Empty;
}