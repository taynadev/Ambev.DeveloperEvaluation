using Ambev.DeveloperEvaluation.Application.Carts.Commands.CreateCartProduct;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Carts.Commands.CreateCart
{
    /// <summary>
    /// Handles the creation of a new cart.
    /// </summary>
    public class CreateCartHandler : IRequestHandler<CreateCartCommand, CreateCartResult>
    {
        private readonly ICartRepository _cartRepository;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        /// <summary>
        /// Initializes a new instance of CreateCartHandler
        /// </summary>
        /// <param name="cartRepository">The cart repository</param>
        /// <param name="mapper">The AutoMapper instance</param>
        public CreateCartHandler(ICartRepository cartRepository, IMapper mapper, IMediator mediator)
        {
            _cartRepository = cartRepository;
            _mapper = mapper;
            _mediator = mediator;
        }

        /// <summary>
        /// Handles the CreateCartCommand request
        /// </summary>
        /// <param name="command">The CreateCart command</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The created Cart details</returns>
        public async Task<CreateCartResult> Handle(CreateCartCommand command, CancellationToken cancellationToken)
        {
            var validator = new CreateCartValidator();
            var validation = await validator.ValidateAsync(command, cancellationToken);

            if (!validation.IsValid)
                throw new ValidationException(validation.Errors);

            var cart = _mapper.Map<Cart>(command);
            var created = await _cartRepository.CreateAsync(cart, cancellationToken);
            var result = _mapper.Map<CreateCartResult>(created);

            foreach (var item in cart.CartProducts)
            {
                var addCartProductCommand = new AddCartProductCommand
                {
                    UserId = cart.UserId,
                    ProductId = item.ProductId,
                    Quantity = item.Quantity
                };
                await _mediator.Send(addCartProductCommand, cancellationToken);

                result.Products.Add(new CartProductResultDto
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity
                });
            }

            
            return result;
        }
    }
}
