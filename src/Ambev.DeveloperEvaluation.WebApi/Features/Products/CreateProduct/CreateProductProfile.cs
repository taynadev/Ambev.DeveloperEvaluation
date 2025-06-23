using Ambev.DeveloperEvaluation.Application.Products.Commands.CreateProduct;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProduct;

/// <summary>
/// Profile for mapping between Application and API CreateProduct responses
/// </summary>
public class CreateProductProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for CreateProduct feature
    /// </summary>
    public CreateProductProfile()
    {
        CreateMap<CreateProductRequest, CreateProductCommand>();
        CreateMap<RatingDtoRequest, RatingDto>();
        CreateMap<CreateProductResult, CreateProductResponse>();
        CreateMap<RatingDtoResult, RatingDtoResponse>();
    }
}
