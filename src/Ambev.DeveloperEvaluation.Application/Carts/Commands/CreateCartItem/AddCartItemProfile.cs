using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Carts.Commands.CreateCartItem
{
    /// <summary>
    /// AutoMapper profile for AddCartItemCommand and related mappings.
    /// </summary>
    public class AddCartItemProfile : Profile
    {
        public AddCartItemProfile()
        {
            CreateMap<Cart, AddCartItemResult>();
        }
    }
}
