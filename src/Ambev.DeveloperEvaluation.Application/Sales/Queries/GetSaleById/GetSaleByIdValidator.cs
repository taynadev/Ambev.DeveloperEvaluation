using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Sales.Queries.GetSaleById
{
    /// <summary>
    /// Validator for <see cref="GetSaleByIdCommand"/>.
    /// </summary>
    public class GetSaleByIdValidator : AbstractValidator<GetSaleByIdCommand>
    {
        public GetSaleByIdValidator()
        {
            RuleFor(x => x.SaleId).NotEmpty().WithMessage("Sale ID must be provided.");
        }
    }
}
