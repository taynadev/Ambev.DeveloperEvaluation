using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.Queries.GetSaleById
{
    /// <summary>
    /// Handles the logic to retrieve a sale by its ID.
    /// </summary>
    public class GetSaleByIdHandler : IRequestHandler<GetSaleByIdQuery, GetSaleByIdResult>
    {
        private readonly ISaleRepository _saleRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetSaleByIdHandler"/> class.
        /// <param name="saleRepository">The sale repository</param>
        /// <param name="mapper"> The AutoMapper instance</param>
        public GetSaleByIdHandler(ISaleRepository saleRepository, IMapper mapper)
        {
            _saleRepository = saleRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Handles the GetSaleByIdQuery request
        /// </summary>
        /// <param name="command">The GetSaleById query</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The Sale deatails</returns>
        public async Task<GetSaleByIdResult> Handle(GetSaleByIdQuery query, CancellationToken cancellationToken)
        {
            var validator = new GetSaleByIdValidator();
            var validationResult = await validator.ValidateAsync(query, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var sale = await _saleRepository.GetByIdAsync(query.SaleId, cancellationToken);

            if (sale is null)
                throw new InvalidOperationException("Sale not found.");

            var result = _mapper.Map<GetSaleByIdResult>(sale);
            return result;
        }
    }
}
