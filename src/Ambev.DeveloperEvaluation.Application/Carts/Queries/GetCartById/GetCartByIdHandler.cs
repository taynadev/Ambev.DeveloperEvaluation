using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Carts.Queries.GetCartById
{
    /// <summary>
    /// Handler for processing <see cref="GetCartByIdCommand"/> requests.
    /// </summary>
    public class GetCartByIdHandler : IRequestHandler<GetCartByIdCommand, GetCartByIdResult>
    {
        private readonly ICartRepository _cartRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of GetCartByIdHandler
        /// </summary>
        /// <param name="cartRepository">The cart repository</param>
        /// <param name="mapper">The AutoMapper instance</param>
        public GetCartByIdHandler(ICartRepository cartRepository, IMapper mapper)
        {
            _cartRepository = cartRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Handles the GetCartByIdQuery request
        /// </summary>
        /// <param name="query">The GetCartById query</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The cart details if found</returns>
        public async Task<GetCartByIdResult> Handle(GetCartByIdCommand query, CancellationToken cancellationToken)
        {
            var validator = new GetCartByIdQueryValidator();
            var validationResult = await validator.ValidateAsync(query, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var cart = await _cartRepository.GetByIdAsync(query.Id, cancellationToken);
            if (cart == null)
                throw new InvalidOperationException("Cart not found.");

            return _mapper.Map<GetCartByIdResult>(cart);
        }
    }
}