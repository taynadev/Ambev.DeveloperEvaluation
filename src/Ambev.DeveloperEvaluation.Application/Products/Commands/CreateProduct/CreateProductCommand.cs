using Ambev.DeveloperEvaluation.Common.Validation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.Commands.CreateProduct
{
    /// <summary>
    /// Command to create a new product.
    /// </summary>
    /// <remarks>
    /// This command is responsible for initializing a product with a customer and branch.
    ///  It implements <see cref="IRequest{TResponse}"/> to initiate the request 
    /// that returns a <see cref="CreateProductResult"/>.
    /// 
    /// The data provided in this command is validated using the 
    /// <see cref="CreateProductValidator"/> which extends 
    /// <see cref="AbstractValidator{T}"/> to ensure that the fields are correctly 
    /// populated and follow the required rules.
    /// </remarks>
    public class CreateProductCommand : IRequest<CreateProductResult>
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
        public RatingDto? Rating { get; set; }


        public ValidationResultDetail Validate()
        {
            var validator = new CreateProductValidator();
            var result = validator.Validate(this);
            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(e => (ValidationErrorDetail)e)
            };
        }
    }

    /// <summary>
    /// Provides the rating details for a product.
    /// </summary>
    public class RatingDto
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