using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Validation;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    /// <summary>
    /// Represents a product available for sale in the system.
    /// Includes product identification, pricing, and availability status.
    /// </summary>
    public class Product : BaseEntity
    {
        /// <summary>
        /// Gets or sets the name of the product.
        /// </summary>
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the base unit price of the product.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets the description of the product.
        /// Optional field used for product details.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Gets or sets the category of the product.
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// Gets or sets the URL or file path of the image associated with the object.
        /// </summary>
        public string Image { get; set; }

        /// <summary>
        /// Gets or sets the rating associated with the product.
        /// </summary>
        public Rating? Rating { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the product is active.
        /// Inactive products cannot be added to a sale.
        /// </summary>
        public bool IsActive { get; set; } = true;

        /// <summary>
        /// Performs validation of the Produtc entity using the ProductValidator rules.
        /// </summary>
        /// <returns>
        /// A <see cref="ValidationResultDetail"/> containing:
        /// - IsValid: Indicates whether all validation rules passed
        /// - Errors: Collection of validation errors if any rules failed
        /// </returns>
        /// <remarks>
        /// <listheader>The validation includes checking:</listheader>
        /// <list type="bullet">Name provided and length</list>
        /// <list type="bullet">Description length</list>
        /// </remarks>
        public ValidationResultDetail Validate()
        {
            var validator = new ProductValidator();
            var result = validator.Validate(this);
            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
            };
        }
    }
}
