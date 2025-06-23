using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Products.Queries.GetProductById
{
    /// <summary>
    /// Validator for <see cref="GetProductByIdCommand"/>.
    /// </summary>
    public class GetProductByIdValidator : AbstractValidator<GetProductByIdCommand>
    {
        public GetProductByIdValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Product ID must be provided.");
        }
    }
}
