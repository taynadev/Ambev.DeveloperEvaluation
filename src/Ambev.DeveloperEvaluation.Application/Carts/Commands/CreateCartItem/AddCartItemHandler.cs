using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Carts.Commands.CreateCartItem
{
    /// <summary>
    /// Handler for processing <see cref="AddCartItemCommand"/> requests.
    /// </summary>
    public class AddCartItemHandler : IRequestHandler<AddCartItemCommand, AddCartItemResult>
    {
        private readonly ICartRepository _cartRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of AddCartItemHandler
        /// </summary>
        /// <param name="cartRepository">The Cart repository</param>
        /// <param name="mapper">The AutoMapper instance</param>
        public AddCartItemHandler(ICartRepository cartRepository, IMapper mapper)
        {
            _cartRepository = cartRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Handles the AddCartItemCommand request
        /// </summary>
        /// <param name="command">The AddCartItem command</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The cart details</returns>
        public async Task<AddCartItemResult> Handle(AddCartItemCommand command, CancellationToken cancellationToken)
        {
            var validator = new AddCartItemValidator();
            var validationResult = await validator.ValidateAsync(command, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var cart = await _cartRepository.GetByIdAsync(command.CartId, cancellationToken);
            if (cart == null)
                throw new InvalidOperationException("Cart not found.");

            cart.AddItem(command.ProductId, command.ProductName, command.Quantity, command.UnitPrice);

            await _cartRepository.UpdateAsync(cart, cancellationToken);

            return new AddCartItemResult
            {
                CartId = cart.Id,
                TotalAmount = cart.TotalAmount,
                TotalAmountWithDiscount = cart.TotalAmountWithDiscount
            };
        }
    }
}
