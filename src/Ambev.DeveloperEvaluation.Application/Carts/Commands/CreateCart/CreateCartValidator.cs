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
        /// - CustomerName: Required
        public CreateCartValidator()
        {
            RuleFor(c => c.CustomerId).NotEmpty();
            RuleFor(c => c.CustomerName).NotEmpty();
        }
    }
}
