using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Carts.Commands.CreateCartProduct
{
    /// <summary>
    /// AutoMapper profile for AddCartProductCommand and related mappings.
    /// </summary>
    public class AddCartProductProfile : Profile
    {
        public AddCartProductProfile()
        {
            CreateMap<Cart, AddCartProductResult>();
        }
    }
}
