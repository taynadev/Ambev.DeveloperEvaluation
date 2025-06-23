using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.Commands.CreateSale
{
    /// <summary>
    /// Validates rules for  <see cref="CreateSaleCommand"/>.
    /// </summary>
    public class CreateSaleValidator : AbstractValidator<CreateSaleCommand>
    {
        /// <summary>
        /// Initializes a new instance of the CreateSaleValidator with defined validation rules.
        /// </summary>
        /// <remarks>
        /// Validation rules include:
        ///  - UserId: Required
        ///  - CustomerName: Required and length limited to 100 characters
        ///  - BranchId: Required
        ///  - BranchName: Required and length limited to 100 characters
        ///  - Items: At least one item is required
        public CreateSaleValidator()
        {
            RuleFor(x => x.UserId).NotEmpty();
            RuleFor(x => x.CustomerName).NotEmpty().MaximumLength(100);
            RuleFor(x => x.BranchId).NotEmpty();
            RuleFor(x => x.BranchName).NotEmpty().MaximumLength(100);

            RuleFor(x => x.Items)
                .NotEmpty().WithMessage("At least one item is required.");

            RuleForEach(x => x.Items).SetValidator(new CreateSaleItemDtoValidator());
        }

        /// <summary>
        /// Initializes a new instance of the CreateSaleItemDtoValidator with defined validation rules.
        /// </summary>
        /// <remarks>
        /// Validation rules include:
        /// - ProductId: Required
        /// - ProductName: Required and length limited to 100 characters
        /// - Quantity: Required and limits the quantity to be between 1 and 20.
        private class CreateSaleItemDtoValidator : AbstractValidator<CreateSaleItemDto>
        {
            public CreateSaleItemDtoValidator()
            {
                RuleFor(x => x.ProductId).NotEmpty();
                RuleFor(x => x.ProductName).NotEmpty().MaximumLength(100);
                RuleFor(x => x.Quantity).GreaterThan(0).LessThanOrEqualTo(20);
            }
        }
    }
}
