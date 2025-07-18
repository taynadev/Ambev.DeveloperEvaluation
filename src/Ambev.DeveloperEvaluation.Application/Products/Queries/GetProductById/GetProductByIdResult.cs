﻿using Ambev.DeveloperEvaluation.Application.Products.Commands.CreateProduct;

namespace Ambev.DeveloperEvaluation.Application.Products.Queries.GetProductById
{
    /// <summary>
    /// Represents the detailed result of a product queried by ID.
    /// </summary>
    /// <remarks>
    /// Contains all relevant information about a product, including metadata,
    /// customer and branch data, cancellation status, and itemized product details.
    /// </remarks>
    public class GetProductByIdResult
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
        public RatingDtoResult? Rating { get; set; }
    }

    /// <summary>
    /// Provides the rating details for a product.
    /// </summary>
    public class RatingDtoResult
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
