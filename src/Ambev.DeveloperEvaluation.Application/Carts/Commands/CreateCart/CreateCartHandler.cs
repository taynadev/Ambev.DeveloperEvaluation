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
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        /// <summary>
        /// Initializes a new instance of CreateCartHandler
        /// </summary>
        /// <param name="cartRepository">The cart repository</param>
        /// <param name="productRepository">The product repository</param>
        /// <param name="mapper">The AutoMapper instance</param>
        public CreateCartHandler(ICartRepository cartRepository, IProductRepository productRepository, IMapper mapper, IMediator mediator)
        {
            _cartRepository = cartRepository;
            _productRepository = productRepository;
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

            foreach (var item in command.Products)
            {
                var product = await _productRepository.GetByIdAsync(item.ProductId, cancellationToken);
                if (cart == null)
                    throw new InvalidOperationException($"Product with id '{item.ProductId}' not found.");

                cart.AddItem(item.ProductId, item.Quantity, product!.Price);
            }

            var created = await _cartRepository.CreateAsync(cart, cancellationToken);
            var result = _mapper.Map<CreateCartResult>(created);            

            
            return result;
        }
    }
}
