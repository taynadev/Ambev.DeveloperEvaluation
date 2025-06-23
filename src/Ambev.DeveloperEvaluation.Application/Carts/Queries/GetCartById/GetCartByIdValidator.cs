using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Carts.Queries.GetCartById
{
    /// <summary>
    /// Validator for <see cref="GetCartByIdCommand"/>, ensuring a valid CartId is provided.
    /// </summary>
    public class GetCartByIdQueryValidator : AbstractValidator<GetCartByIdCommand>
    {
        /// <summary>
        /// Initializes a new instance of the GetCartByIdQueryValidator with defined validation rules.
        /// </summary>
        /// <remarks>
        /// Validation rules include:
        ///  - CartId: Required
        public GetCartByIdQueryValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("CartId must be provided.");
        }
    }
}