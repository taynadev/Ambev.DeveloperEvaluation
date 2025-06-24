using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.Queries.GetSale
{
    /// <summary>
    /// Handler for processing <see cref="GetSalesCommand"/> requests.
    /// </summary>
    public class GetSalesHandler : IRequestHandler<GetSalesCommand, GetSalesResult>
    {
        private readonly ISaleRepository _saleRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of GetSaleHandler
        /// </summary>
        /// <param name="saleRepository">The sale repository</param>
        /// <param name="mapper">The AutoMapper instance</param>
        public GetSalesHandler(ISaleRepository saleRepository, IMapper mapper)
        {
            _saleRepository = saleRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Handles the GetSaleQuery request
        /// </summary>
        /// <param name="query">The GetSale query</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The sale details if found</returns>
        public async Task<GetSalesResult> Handle(GetSalesCommand query, CancellationToken cancellationToken)
        {
            var (items, total) = await _saleRepository.ListWithQueryParamsAsync(query.QueryParams);

            int page = query.QueryParams.TryGetValue("_page", out var p) && int.TryParse(p, out var pg) ? pg : 1;
            int size = query.QueryParams.TryGetValue("_size", out var s) && int.TryParse(s, out var sz) ? sz : 10;

            return new GetSalesResult
            {
                CurrentPage = page,
                TotalItems = total,
                TotalPages = (int)Math.Ceiling(total / (double)size),
                Data = _mapper.Map<List<SaleDto>>(items)
            };
        }
    }
}