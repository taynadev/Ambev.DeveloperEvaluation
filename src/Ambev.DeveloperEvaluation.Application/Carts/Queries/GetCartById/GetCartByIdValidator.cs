using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Carts.Queries.GetCartById
{
    /// <summary>
    /// Validator for <see cref="GetCartByIdQuery"/>, ensuring a valid CartId is provided.
    /// </summary>
    public class GetCartByIdQueryValidator : AbstractValidator<GetCartByIdQuery>
    {
        /// <summary>
        /// Initializes a new instance of the GetCartByIdQueryValidator with defined validation rules.
        /// </summary>
        /// <remarks>
        /// Validation rules include:
        ///  - CartId: Required
        public GetCartByIdQueryValidator()
        {
            RuleFor(x => x.CartId).NotEmpty().WithMessage("CartId must be provided.");
        }
    }
}