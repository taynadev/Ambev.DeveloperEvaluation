using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Validation;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ambev.DeveloperEvaluation.Domain.Entities;


/// <summary>
/// Represents a complete sale transaction including customer, branch, and items.
/// This aggregate root controls sale consistency and business rules.
/// </summary>
public class Sale : BaseEntity
{
    /// <summary>
    /// Gets the unique number assigned to this sale.
    /// </summary>
    public long SaleNumber { get; private set; }

    /// <summary>
    /// Gets the date and time when the sale was created.
    /// </summary>
    public DateTime SaleDate { get; private set; }

    /// <summary>
    /// Gets the ID of the customer making the purchase.
    /// </summary>
    public Guid UserId { get; private set; }

    /// <summary>
    /// Gets the name of the customer, denormalized for display.
    /// </summary>
    public string UserName { get; private set; }

    /// <summary>
    /// Gets the ID of the branch where the sale occurred.
    /// </summary>
    public Guid BranchId { get; private set; }

    /// <summary>
    /// Gets the name of the branch, denormalized for display.
    /// </summary>
    public string BranchName { get; private set; }

    /// <summary>
    /// Gets the list of items included in this sale.
    /// </summary>
    private readonly List<SaleItem> _items = new();
    public IReadOnlyCollection<SaleItem> Items => _items.AsReadOnly();

    /// <summary>
    /// Gets the total amount of the sale, excluding cancelled items.
    /// </summary>
    [NotMapped]
    public decimal TotalAmount => _items.Where(i => !i.IsCanceled).Sum(i => i.TotalAmount);

    /// <summary>
    /// Gets the total amount with discount of the sale, excluding cancelled items.
    /// </summary>
    [NotMapped]
    public decimal TotalAmountWithDiscount => _items.Where(i => !i.IsCanceled).Sum(i => i.TotalAmountWithDiscount);

    /// <summary>
    /// Gets a value indicating whether the entire sale has been cancelled.
    /// </summary>
    public bool IsCanceled { get; private set; }

    /// <summary>
    /// Performs validation of the Sale entity using the SaleValidator rules.
    /// </summary>
    /// <returns>
    /// A <see cref="ValidationResultDetail"/> containing:
    /// - IsValid: Indicates whether all validation rules passed
    /// - Errors: Collection of validation errors if any rules failed
    /// </returns>
    /// <remarks>
    /// <listheader>The validation includes checking:</listheader>
    /// <list type="bullet">SaleNumber provided and length</list>
    /// <list type="bullet">SaleDate provided and value</list>
    /// <list type="bullet">UserId provided</list>
    /// <list type="bullet">CustomerName provided</list>
    /// <list type="bullet">BranchId provided</list>
    /// <list type="bullet">BranchName  provided and length</list>
    /// </remarks>
    public ValidationResultDetail Validate()
    {
        var validator = new SaleValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Sale"/> class.
    /// </summary>
    protected Sale() { }

    /// <summary>
    /// Initializes a new instance of the <see cref="Sale"/> class.
    /// Sets base information and timestamps.
    /// </summary>
    /// <param name="saleNumber">The unique number of the sale.</param>
    /// <param name="userId">The ID of the customer.</param>
    /// <param name="customerName">The name of the customer.</param>
    /// <param name="branchId">The ID of the branch.</param>
    /// <param name="branchName">The name of the branch.</param>
    public Sale(Guid userId, string customerName, Guid branchId, string branchName)
    {
        SaleDate = DateTime.UtcNow;
        UserId = userId;
        UserName = customerName;
        BranchId = branchId;
        BranchName = branchName;
    }

    /// <summary>
    /// Static factory method to create a sale from a cart.
    /// </summary>
    /// <param name="cart">The cart containing the products.</param>
    /// <param name="customerName">The name of the customer (denormalized).</param>
    /// <param name="branchId">The ID of the branch.</param>
    /// <param name="branchName">The name of the branch (denormalized).</param>
    /// <param name="saleNumber">The unique number of the sale.</param>
    /// <returns>A fully initialized <see cref="Sale"/> object.</returns>
    /// <exception cref="ArgumentNullException">Thrown if cart is null.</exception>
    public static Sale CreateFromCart(Cart cart, string customerName, Guid branchId, string branchName)
    {
        if (cart is null)
            throw new ArgumentNullException(nameof(cart));

        var sale = new Sale(cart.UserId, customerName, branchId, branchName);

        foreach (var item in cart.CartProducts)
        {
            sale.AddItem(item.ProductId, item.Product.Name, item.Quantity, item.Product.UnitPrice);
        }

        return sale;
    }


    /// <summary>
    /// Adds a new item to the sale.
    /// Applies all related business rules from the SaleItem entity.
    /// </summary>
    /// <param name="productId">The ID of the product.</param>
    /// <param name="productName">The name of the product.</param>
    /// <param name="quantity">Quantity of the product.</param>
    /// <param name="unitPrice">Price per unit of the product.</param>
    public void AddItem(Guid productId, string productName, int quantity, decimal unitPrice)
    {
        if (IsCanceled)
            throw new InvalidOperationException("Cannot add item to a cancelled sale");

        var item = new SaleItem(productId, productName, quantity, unitPrice);
        _items.Add(item);
    }

    /// <summary>
    /// Cancels the entire sale and all of its items.
    /// </summary>
    public void Cancel()
    {
        IsCanceled = true;
        foreach (var item in _items)
            item.Cancel();
    }

    /// <summary>
    /// Cancels a specific item within the sale.
    /// </summary>
    /// <param name="itemId">The ID of the item to cancel.</param>
    public void CancelItem(Guid itemId)
    {
        var item = _items.FirstOrDefault(i => i.Id == itemId);
        if (item is null)
            throw new InvalidOperationException("Item not found");

        item.Cancel();
    }
}