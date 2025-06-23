using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Validation;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

/// <summary>
/// Represents an item in a customer's cart.
/// Handles quantity and pricing logic with discount calculation.
/// </summary>
public class CartProduct : BaseEntity
{
    /// <summary>
    /// Gets or sets the quantity of the product.
    /// </summary>
    public int Quantity { get; private set; }

    /// <summary>
    /// Gets or sets the identifier of the cart this item belongs to.
    /// </summary>
    public Guid CartId { get; set; }

    /// <summary>
    /// Gets or sets the cart this item belongs to.
    /// </summary>
    public Cart Cart { get; set; }

    /// <summary>
    /// Gets or sets the product ID added to the cart.
    /// </summary>
    public Guid ProductId { get; private set; }

    /// <summary>
    /// Gets or sets the product added to the cart.
    /// </summary>
    public Product Product { get; private set; }

    /// <summary>
    /// Gets the total amount without discount.
    /// </summary>
    [NotMapped]
    public decimal TotalAmount => Quantity * Product.Price;

    /// <summary>
    /// Gets the applicable discount percentage.
    /// </summary>
    [NotMapped]
    public decimal DiscountPercentage =>
        Quantity >= 10 ? 0.20m :
        Quantity >= 4 ? 0.10m : 0m;

    /// <summary>
    /// Gets the amount discounted.
    /// </summary>
    [NotMapped]
    public decimal DiscountAmount => TotalAmount * DiscountPercentage;

    /// <summary>
    /// Gets the total price with discount applied.
    /// </summary>
    [NotMapped]
    public decimal TotalAmountWithDiscount => TotalAmount - DiscountAmount;

    /// <summary>
    /// Increases the quantity of this item in the cart.
    /// </summary>
    public void IncreaseQuantity(int amount)
    {
        if (amount <= 0)
            throw new InvalidOperationException("Quantity must be greater than zero.");
        Quantity += amount;
    }

    /// <summary>
    /// Initializes a new instance of the CartProduct class.
    /// </summary>
    public CartProduct(Guid productId, int quantity)
    {
        ProductId = productId;
        Quantity = quantity;
    }

    /// <summary>
    /// Performs validation of the CartProduct entity using the CartProductValidator rules.
    /// </summary>
    /// <returns>
    /// A <see cref="ValidationResultDetail"/> containing:
    /// - IsValid: Indicates whether all validation rules passed
    /// - Errors: Collection of validation errors if any rules failed
    /// </returns>
    /// <remarks>
    /// <listheader>The validation includes checking:</listheader>
    /// <list type="bullet">ProductId and ProductName must be provided</list>
    /// <list type="bullet">Quantity must be positive</list>
    /// </remarks>
    public ValidationResultDetail Validate()
    {
        var validator = new CartProductValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }

    /// <summary>
    /// Initializes a new instance of the CartProduct class.
    /// </summary>
    protected CartProduct() { }
}
