using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Carts.Queries.GetCart
{
    /// <summary>
    /// Handler for processing <see cref="GetCartsCommand"/> requests.
    /// </summary>
    public class GetCartsHandler : IRequestHandler<GetCartsCommand, GetCartsResult>
    {
        private readonly ICartRepository _cartRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of GetCartHandler
        /// </summary>
        /// <param name="cartRepository">The cart repository</param>
        /// <param name="mapper">The AutoMapper instance</param>
        public GetCartsHandler(ICartRepository cartRepository, IMapper mapper)
        {
            _cartRepository = cartRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Handles the GetCartQuery request
        /// </summary>
        /// <param name="query">The GetCart query</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The cart details if found</returns>
        public async Task<GetCartsResult> Handle(GetCartsCommand query, CancellationToken cancellationToken)
        {
            var (items, total) = await _cartRepository.ListWithQueryParamsAsync(query.QueryParams);

            int page = query.QueryParams.TryGetValue("_page", out var p) && int.TryParse(p, out var pg) ? pg : 1;
            int size = query.QueryParams.TryGetValue("_size", out var s) && int.TryParse(s, out var sz) ? sz : 10;

            return new GetCartsResult
            {
                CurrentPage = page,
                TotalItems = total,
                TotalPages = (int)Math.Ceiling(total / (double)size),
                Data = _mapper.Map<List<CartDto>>(items)
            };
        }
    }
}