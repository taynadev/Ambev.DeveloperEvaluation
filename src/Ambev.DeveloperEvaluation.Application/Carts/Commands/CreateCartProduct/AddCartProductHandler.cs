using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Carts.Commands.CreateCartProduct
{
    /// <summary>
    /// Handler for processing <see cref="AddCartProductCommand"/> requests.
    /// </summary>
    public class AddCartProductHandler : IRequestHandler<AddCartProductCommand, AddCartProductResult>
    {
        private readonly ICartRepository _cartRepository;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of AddCartProductHandler
        /// </summary>
        /// <param name="cartRepository">The Cart repository</param>
        /// <param name="productRepository"> The Product repository</param>
        /// <param name="mapper">The AutoMapper instance</param>
        public AddCartProductHandler(ICartRepository cartRepository, IProductRepository productRepository, IMapper mapper)
        {
            _cartRepository = cartRepository;
            _productRepository = productRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Handles the AddCartProductCommand request
        /// </summary>
        /// <param name="command">The AddCartProduct command</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The cart details</returns>
        public async Task<AddCartProductResult> Handle(AddCartProductCommand command, CancellationToken cancellationToken)
        {
            var validator = new AddCartProductValidator();
            var validationResult = await validator.ValidateAsync(command, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var cart = await _cartRepository.GetByUserIdAsync(command.UserId, cancellationToken);
            if (cart == null)
                throw new InvalidOperationException("Cart not found.");

            var product = await _productRepository.GetByIdAsync(command.ProductId, cancellationToken);
            if (cart == null)
                throw new InvalidOperationException("Product not found.");

            cart.AddItem(command.ProductId, command.Quantity, product!.Price);

            await _cartRepository.UpdateAsync(cart, cancellationToken);

            return new AddCartProductResult
            {
                CartId = cart.Id,
                TotalAmount = cart.TotalAmount,
                TotalAmountWithDiscount = cart.TotalAmountWithDiscount
            };
        }
    }
}
