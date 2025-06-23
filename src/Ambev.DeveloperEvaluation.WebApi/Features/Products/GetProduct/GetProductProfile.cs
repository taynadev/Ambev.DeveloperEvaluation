using Ambev.DeveloperEvaluation.Application.Products.Queries.GetProductById;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProduct
{

    /// <summary>
    /// Profile for mapping GetProduct feature requests to commands
    /// </summary>
    public class GetProductProfile : Profile
    {
        /// <summary>
        /// Initializes the mappings for GetProduct feature
        /// </summary>
        public GetProductProfile()
        {
            CreateMap<Guid, GetProductByIdCommand>()
                .ConstructUsing(id => new GetProductByIdCommand(id));

            CreateMap<GetProductByIdResult, GetProductResponse>();
            CreateMap<RatingDtoResult, RatingResponseDto>();
        }
    }
}
