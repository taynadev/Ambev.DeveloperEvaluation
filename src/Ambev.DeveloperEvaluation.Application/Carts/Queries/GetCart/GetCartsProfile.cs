using Ambev.DeveloperEvaluation.Application.Carts.Queries.GetCart;
using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Carts.Queries.GetCartById
{
    /// <summary>
    /// AutoMapper profile for mapping Cart and CartProduct to their result DTOs.
    /// </summary>
    public class GetCartsProfile : Profile
    {
        public GetCartsProfile()
        {
            CreateMap<Cart, CartDto>();

            CreateMap<CartProduct, CartProductDto>();
        }
    }
}