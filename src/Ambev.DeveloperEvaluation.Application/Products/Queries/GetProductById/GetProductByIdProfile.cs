using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Products.Queries.GetProductById
{
    /// <summary>
    /// AutoMapper profile for mapping <see cref="Product"/> to <see cref="GetProductByIdResult"/>.
    /// </summary>
    public class GetProductByIdProfile : Profile
    {
        public GetProductByIdProfile()
        {
            CreateMap<Rating, RatingDtoResult>();
            CreateMap<Product, GetProductByIdResult>();
        }
    }
}
