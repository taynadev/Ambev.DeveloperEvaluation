using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Carts.Commands.CreateCart
{
    /// <summary>
    /// Validator for the CreateCartCommand.
    /// </summary>
    public class CreateCartValidator : AbstractValidator<CreateCartCommand>
    {
        /// <summary>
        /// Initializes a new instance of the CreateCartCommandValidator with defined validation rules.
        /// </summary>
        /// <remarks>
        /// Validation rules include:
        /// - CustomerId: Required
        public CreateCartValidator()
        {
            RuleFor(c => c.UserId).NotEmpty();     
            
            RuleFor(c => c.Products)
                .ForEach(product => product.SetValidator(new CartProductDtoValidator()));
        }
    }

    /// <summary>
    /// Validator for the CartProductDto.
    /// </summary>
    public class CartProductDtoValidator : AbstractValidator<CartProductDto>
    {
        /// <summary>
        /// Initializes a new instance of the CreateCartCommandValidator with defined validation rules.
        /// </summary>
        /// <remarks>
        /// Validation rules include:
        /// - ProductId: Required
        /// - Quantity: Must be greater than 0 and less than or equal to 20.
        public CartProductDtoValidator()
        {
            RuleFor(c => c.ProductId).NotEmpty();
            RuleFor(c => c.Quantity).GreaterThan(0).LessThanOrEqualTo(20);
        }
    }
}
