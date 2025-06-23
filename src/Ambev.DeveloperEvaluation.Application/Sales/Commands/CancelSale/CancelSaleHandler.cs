using Ambev.DeveloperEvaluation.Domain.Repositories;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.Commands.CancelSale
{
    /// <summary>
    /// Handles cancellation of a sale and all its items.
    /// </summary>
    public class CancelSaleHandler : IRequestHandler<CancelSaleCommand, CancelSaleResult>
    {
        private readonly ISaleRepository _saleRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="CancelSaleHandler"/> class.
        /// <param name="saleRepository">The sale repository</param>
        public CancelSaleHandler(ISaleRepository saleRepository)
        {
            _saleRepository = saleRepository;
        }

        /// <summary>
        /// Handles the CancelSaleCommand request
        /// </summary>
        /// <param name="command">The CancelSale command</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The id of the sale canceled</returns>
        public async Task<CancelSaleResult> Handle(CancelSaleCommand command, CancellationToken cancellationToken)
        {
            var validator = new CancelSaleValidator();
            var validationResult = await validator.ValidateAsync(command, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var sale = await _saleRepository.GetByIdAsync(command.SaleId, cancellationToken);
            if (sale == null)
                throw new InvalidOperationException("Sale not found.");

            sale.Cancel();

            await _saleRepository.UpdateAsync(sale, cancellationToken);

            return new CancelSaleResult { SaleId = sale.Id };
        }
    }
}
