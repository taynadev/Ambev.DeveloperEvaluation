using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Products.Commands.CreateProduct
{
    /// <summary>
    /// AutoMapper profile for product creation.
    /// </summary>
    public class CreateProductProfile : Profile
    {
        public CreateProductProfile()
        {
            CreateMap<CreateProductCommand, Product>();
            CreateMap<RatingDto, Rating>();
            CreateMap<Product, CreateProductResult>();
            CreateMap<Rating, RatingDtoResult>();

        }
    }
}