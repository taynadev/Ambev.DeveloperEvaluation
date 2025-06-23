using Ambev.DeveloperEvaluation.Domain.Repositories;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Carts.Commands.RemoveCartProduct
{
    /// <summary>
    /// Handler for processing <see cref="RemoveCartProductCommand"/> requests.
    /// </summary>
    public class RemoveCartProductHandler : IRequestHandler<RemoveCartProductCommand, RemoveCartProductResult>
    {
        private readonly ICartRepository _cartRepository;

        /// <summary>
        /// Initializes a new instance of RemoveCartProductHandler
        /// </summary>
        /// <param name="cartRepository">The Cart repository</param>
        public RemoveCartProductHandler(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }


        /// <summary>
        /// Handles the RemoveCartProductCommand request
        /// </summary>
        /// <param name="command">The RemoveCartProduct command</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The cart removed details</returns>
        public async Task<RemoveCartProductResult> Handle(RemoveCartProductCommand command, CancellationToken cancellationToken)
        {
            var validator = new RemoveCartProductValidator();
            var validationResult = await validator.ValidateAsync(command, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var cart = await _cartRepository.GetByIdAsync(command.CartId, cancellationToken);
            if (cart == null)
                throw new InvalidOperationException("Cart not found.");

            cart.RemoveItem(command.ItemId);

            await _cartRepository.UpdateAsync(cart, cancellationToken);

            return new RemoveCartProductResult
            {
                CartId = cart.Id,
                TotalAmount = cart.TotalAmount,
                TotalAmountWithDiscount = cart.TotalAmountWithDiscount
            };
        }
    }
}
