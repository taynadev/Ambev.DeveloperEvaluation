using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    /// <summary>
    /// Represents a rating for a product in the system.
    /// </summary>
    public class Rating : BaseEntity
    {
        /// <summary>
        /// The rating of the product.
        /// </summary>
        public decimal Rate { get; set; }

        /// <summary>
        /// The number of reviews for the product.
        /// </summary>
        public int? Count { get; set; }

        /// <summary>
        /// The identifier of the product associated with this rating.
        /// </summary>
        public Guid ProductId { get; set; }

        /// <summary>
        /// The product associated with this rating.
        /// </summary>
        public Product Product { get; set; }
    }
}
