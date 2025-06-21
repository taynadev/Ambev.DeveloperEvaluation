using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    /// <summary>
    /// Represents an item in a sale transaction.
    /// Includes quantity-based discount rules and cancellation control.
    /// </summary>
    public class SaleItem : BaseEntity
    {
        /// <summary>
        /// Gets or sets the identifier of the sale this item belongs to.
        /// </summary>
        public Guid SaleId { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the product.
        /// Used for external reference and denormalization.
        /// </summary>
        public Guid ProductId { get; set; }

        /// <summary>
        /// Gets or sets the name of the product.
        /// Denormalized for better performance and resilience.
        /// </summary>
        public string ProductName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the quantity of the product sold.
        /// Must be between 1 and 20 inclusive.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets the unit price of the product at the time of the sale.
        /// </summary>
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// Gets the total amount for the item before discount.
        /// </summary>
        [NotMapped]
        public decimal TotalAmount => UnitPrice * Quantity;

        /// <summary>
        /// Gets the discount percentage applied based on quantity rules.
        /// - 4 to 9 items: 10%
        /// - 10 to 20 items: 20%
        /// - 1 to 3 items: 0%
        /// </summary>
        [NotMapped]
        public decimal DiscountPercentage
        {
            get
            {
                if (Quantity >= 10 && Quantity <= 20)
                    return 0.20m;
                if (Quantity >= 4)
                    return 0.10m;
                return 0m;
            }
        }

        /// <summary>
        /// Gets the total discount amount.
        /// </summary>
        [NotMapped]
        public decimal DiscountAmount => TotalAmount * DiscountPercentage;

        /// <summary>
        /// Gets the total amount after applying discount.
        /// </summary>
        [NotMapped]
        public decimal TotalAmountWithDiscount => TotalAmount - DiscountAmount;

        /// <summary>
        /// Indicates whether the item has been canceled.
        /// Canceled items are ignored in sale totals.
        /// </summary>
        public bool IsCanceled { get; private set; } = false;

        /// <summary>
        /// Cancels this sale item.
        /// </summary>
        public void Cancel()
        {
            IsCanceled = true;
        }

        /// <summary>
        /// Performs validation of the SaleItem entity using the SaleValidator rules.
        /// </summary>
        /// <returns>
        /// A <see cref="ValidationResultDetail"/> containing:
        /// - IsValid: Indicates whether all validation rules passed
        /// - Errors: Collection of validation errors if any rules failed
        /// </returns>
        /// <remarks>
        /// <listheader>The validation includes checking:</listheader>
        /// <list type="bullet">ProductId provided</list>
        /// <list type="bullet">ProductName provided</list>
        /// </remarks>
        public ValidationResultDetail Validate()
        {
            var validator = new SaleItemValidator();
            var result = validator.Validate(this);
            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
            };
        }

        /// <summary>
        /// Validates the business rules related to quantity.
        /// </summary>
        /// <exception cref="InvalidOperationException">
        /// Thrown when quantity exceeds maximum allowed or is less than 1.
        /// </exception>
        public void ValidateQuantity()
        {
            if (Quantity < 1)
                throw new InvalidOperationException("Quantity must be at least 1.");
            if (Quantity > 20)
                throw new InvalidOperationException("Cannot sell more than 20 items of a single product.");
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SaleItem"/> class.
        /// </summary>
        /// <param name="productId">The product identifier.</param>
        /// <param name="productName">The product name.</param>
        /// <param name="quantity">The quantity sold.</param>
        /// <param name="unitPrice">The unit price at the time of sale.</param>
        public SaleItem(Guid productId, string productName, int quantity, decimal unitPrice)
        {
            ValidateQuantity();

            Id = Guid.NewGuid();
            ProductId = productId;
            ProductName = productName;
            Quantity = quantity;
            UnitPrice = unitPrice;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SaleItem"/> class.
        /// </summary>
        protected SaleItem() { }
    }
}
