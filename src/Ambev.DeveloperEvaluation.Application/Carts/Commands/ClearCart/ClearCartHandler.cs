using Ambev.DeveloperEvaluation.Domain.Repositories;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Carts.Commands.ClearCart
{
    /// <summary>
    /// Handler for processing <see cref="ClearCartCommand"/> requests.
    /// </summary>
    public class ClearCartHandler : IRequestHandler<ClearCartCommand, ClearCartResult>
    {
        private readonly ICartRepository _cartRepository;

        /// <summary>
        /// Initializes a new instance of ClearCartHandler
        /// </summary>
        /// <param name="cartRepository">The cart repository</param>
        public ClearCartHandler(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        /// <summary>
        /// Handles the ClearCartCommand request
        /// </summary>
        /// <param name="command">The ClearCart command</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The cart cleared details</returns>
        public async Task<ClearCartResult> Handle(ClearCartCommand command, CancellationToken cancellationToken)
        {
            var validator = new ClearCartValidator();
            var validationResult = await validator.ValidateAsync(command, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var cart = await _cartRepository.GetByIdAsync(command.CartId, cancellationToken);
            if (cart == null)
                throw new InvalidOperationException("Cart not found.");

            foreach (var item in cart.Items.ToList())
            {
                cart.RemoveItem(item.Id);
            }

            await _cartRepository.UpdateAsync(cart, cancellationToken);

            return new ClearCartResult
            {
                CartId = cart.Id,
                TotalAmount = cart.TotalAmount,
                TotalAmountWithDiscount = cart.TotalAmountWithDiscount
            };
        }
    }
}