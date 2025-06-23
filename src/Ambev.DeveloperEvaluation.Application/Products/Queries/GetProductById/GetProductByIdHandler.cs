using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.Queries.GetProductById
{
    /// <summary>
    /// Handles the logic to retrieve a product by its ID.
    /// </summary>
    public class GetProductByIdHandler : IRequestHandler<GetProductByIdCommand, GetProductByIdResult>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetProductByIdHandler"/> class.
        /// <param name="productRepository">The product repository</param>
        /// <param name="mapper"> The AutoMapper instance</param>
        public GetProductByIdHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Handles the GetProductByIdQuery request
        /// </summary>
        /// <param name="command">The GetProductById query</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The Product deatails</returns>
        public async Task<GetProductByIdResult> Handle(GetProductByIdCommand query, CancellationToken cancellationToken)
        {
            var validator = new GetProductByIdValidator();
            var validationResult = await validator.ValidateAsync(query, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var product = await _productRepository.GetByIdAsync(query.Id, cancellationToken);

            if (product is null)
                throw new InvalidOperationException("Product not found.");

            var result = _mapper.Map<GetProductByIdResult>(product);
            return result;
        }
    }
}
