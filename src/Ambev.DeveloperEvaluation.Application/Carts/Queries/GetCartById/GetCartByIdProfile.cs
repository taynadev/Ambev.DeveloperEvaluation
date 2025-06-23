using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Carts.Queries.GetCartById
{
    /// <summary>
    /// AutoMapper profile for mapping Cart and CartProduct to their result DTOs.
    /// </summary>
    public class GetCartByIdProfile : Profile
    {
        public GetCartByIdProfile()
        {
            CreateMap<Cart, GetCartByIdResult>();

            CreateMap<CartProduct, GetCartProductResult>();
        }
    }
}