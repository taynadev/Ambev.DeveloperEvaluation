using Ambev.DeveloperEvaluation.Domain.Repositories;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Carts.Commands.RemoveCartItem
{
    /// <summary>
    /// Handler for processing <see cref="RemoveCartItemCommand"/> requests.
    /// </summary>
    public class RemoveCartItemHandler : IRequestHandler<RemoveCartItemCommand, RemoveCartItemResult>
    {
        private readonly ICartRepository _cartRepository;

        /// <summary>
        /// Initializes a new instance of RemoveCartItemHandler
        /// </summary>
        /// <param name="cartRepository">The Cart repository</param>
        public RemoveCartItemHandler(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }


        /// <summary>
        /// Handles the RemoveCartItemCommand request
        /// </summary>
        /// <param name="command">The RemoveCartItem command</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The cart removed details</returns>
        public async Task<RemoveCartItemResult> Handle(RemoveCartItemCommand command, CancellationToken cancellationToken)
        {
            var validator = new RemoveCartItemValidator();
            var validationResult = await validator.ValidateAsync(command, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var cart = await _cartRepository.GetByIdAsync(command.CartId, cancellationToken);
            if (cart == null)
                throw new InvalidOperationException("Cart not found.");

            cart.RemoveItem(command.ItemId);

            await _cartRepository.UpdateAsync(cart, cancellationToken);

            return new RemoveCartItemResult
            {
                CartId = cart.Id,
                TotalAmount = cart.TotalAmount,
                TotalAmountWithDiscount = cart.TotalAmountWithDiscount
            };
        }
    }
}
