using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Validation;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

/// <summary>
/// Represents a shopping cart associated with a customer.
/// Includes business rules for managing products before checkout.
/// </summary>
public class Cart : BaseEntity
{
    /// <summary>
    /// Gets the ID of the customer that owns this cart.
    /// </summary>
    public Guid CustomerId { get; private set; }

    /// <summary>
    /// Gets or sets the creation timestamp of the cart.
    /// </summary>
    public DateTime CreatedAt { get; private set; }

    /// <summary>
    /// Gets the list of items currently in the cart.
    /// </summary>
    private readonly List<CartItem> _items = new();
    public IReadOnlyCollection<CartItem> Items => _items.AsReadOnly();

    /// <summary>
    /// Gets the total amount of all items in the cart (without discounts).
    /// </summary>
    [NotMapped]
    public decimal TotalAmount => _items.Sum(i => i.TotalAmount);

    /// <summary>
    /// Gets the total amount of all items in the cart including discounts.
    /// </summary>
    [NotMapped]
    public decimal TotalAmountWithDiscount => _items.Sum(i => i.TotalAmountWithDiscount);

    /// <summary>
    /// Initializes a new instance of the <see cref="Cart"/> class.
    /// </summary>
    protected Cart() { }

    /// <summary>
    /// Initializes a new cart for a specific customer.
    /// </summary>
    /// <param name="customerId">The ID of the customer.</param>
    public Cart(Guid customerId)
    {
        CustomerId = customerId;
        CreatedAt = DateTime.UtcNow;
    }

    /// <summary>
    /// Adds a product to the cart.
    /// </summary>
    public void AddItem(Guid productId, string productName, int quantity, decimal unitPrice)
    {
        var existingItem = _items.FirstOrDefault(i => i.ProductId == productId);
        if (existingItem is not null)
        {
            existingItem.IncreaseQuantity(quantity);
        }
        else
        {
            var item = new CartItem(productId, productName, quantity, unitPrice);
            _items.Add(item);
        }
    }

    /// <summary>
    /// Removes an item from the cart.
    /// </summary>
    public void RemoveItem(Guid itemId)
    {
        var item = _items.FirstOrDefault(i => i.Id == itemId);
        if (item is not null)
            _items.Remove(item);
    }

    /// <summary>
    /// Performs validation of the Cart entity using the CartValidator rules.
    /// </summary>
    /// <returns>
    /// A <see cref="ValidationResultDetail"/> containing:
    /// - IsValid: Indicates whether all validation rules passed
    /// - Errors: Collection of validation errors if any rules failed
    /// </returns>
    /// <remarks>
    /// <listheader>The validation includes checking:</listheader>
    /// <list type="bullet">CustomerId must be provided</list>
    /// </remarks>
    public ValidationResultDetail Validate()
    {
        var validator = new CartValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }
}
