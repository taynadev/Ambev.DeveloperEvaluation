using Ambev.DeveloperEvaluation.Application.Carts.Commands.ClearCart;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.Commands.CreateSaleFromCart
{
    /// <summary>
    /// Handles the creation of a sale based on the contents of a cart.
    /// </summary>
    public class CreateSaleFromCartHandler : IRequestHandler<CreateSaleFromCartCommand, CreateSaleFromCartResult>
    {
        private readonly ICartRepository _cartRepository;
        private readonly ISaleRepository _saleRepository;
        private readonly IMediator _mediator;

        /// <summary>
        /// Initializes a new instance of CreateSaleFromCartHandler
        /// </summary>
        /// <param name="cartRepository">The Cart repository</param>
        /// <param name="saleRepository">The Sale repository</param>
        /// <param name="mapper">The AutoMapper instance</param>
        /// <param name="mediator">The MediatR instance for sending commands</param>
        public CreateSaleFromCartHandler(
            ICartRepository cartRepository,
            ISaleRepository saleRepository,
            IMapper mapper,
            IMediator mediator)
        {
            _cartRepository = cartRepository;
            _saleRepository = saleRepository;
            _mediator = mediator;
        }

        /// <summary>
        /// Handles the CreateSaleFromCartCommand request
        /// </summary>
        /// <param name="command">The CreateSaleFromCart command</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The created Sale details</returns>
        public async Task<CreateSaleFromCartResult> Handle(CreateSaleFromCartCommand command, CancellationToken cancellationToken)
        {
            var validator = new CreateSaleFromCartValidator();
            var validation = await validator.ValidateAsync(command, cancellationToken);
            if (!validation.IsValid)
                throw new ValidationException(validation.Errors);

            var cart = await _cartRepository.GetByIdAsync(command.CartId, cancellationToken);
            if (cart is null)
                throw new InvalidOperationException("Cart not found.");


            var sale = Sale.CreateFromCart(cart, cart.CustomerName, command.BranchId, command.BranchName);

            await _saleRepository.CreateAsync(sale, cancellationToken);

            // Clear cart after sale creation
            await _mediator.Send(new ClearCartCommand { CartId = command.CartId }, cancellationToken);

            return new CreateSaleFromCartResult
            {
                SaleId = sale.Id,
                SaleNumber = sale.SaleNumber
            };
        }
    }
}
