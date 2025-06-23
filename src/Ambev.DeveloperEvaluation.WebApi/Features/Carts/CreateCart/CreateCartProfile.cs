using Ambev.DeveloperEvaluation.Application.Carts.Commands.CreateCart;
using Ambev.DeveloperEvaluation.Application.Carts.Commands.CreateCartProduct;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.CreateCart
{
    public class CreateCartProfile : Profile
    {
        public CreateCartProfile()
        {
            CreateMap<CreateCartRequest, CreateCartCommand>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId));

            CreateMap<CreateCartProductRequest, CartProductDto>();
            CreateMap<CreateCartResult, CreateCartResponse>();
            CreateMap<AddCartProductResult, CreateCartProductesponse>();
        }
    }
}
