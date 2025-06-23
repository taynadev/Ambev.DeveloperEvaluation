namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProduct
{

    /// <summary>
    /// API response model for the GeteProduct operation.
    /// </summary>
    public class GetProductResponse
    {
        /// <summary>
        /// Gets or sets the unique identifier of the created product.
        /// </summary>
        public Guid Id { get; set; }

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
        public RatingResponseDto? Rating { get; set; }
    }

    /// <summary>
    /// Provides the rating details for a product.
    /// </summary>
    public class RatingResponseDto
    {
        /// <summary>
        /// The rating of the product.
        /// </summary>
        public decimal Rate { get; set; }

        /// <summary>
        /// The number of reviews for the product.
        /// </summary>
        public int? Count { get; set; }
    }
}
