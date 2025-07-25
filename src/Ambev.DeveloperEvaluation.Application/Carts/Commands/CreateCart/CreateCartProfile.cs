﻿using Ambev.DeveloperEvaluation.Application.Carts.Commands.CreateCartProduct;
using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Carts.Commands.CreateCart
{
    /// <summary>
    /// AutoMapper profile for cart creation.
    /// </summary>
    public class CreateCartProfile : Profile
    {
        public CreateCartProfile()
        {
            CreateMap<CreateCartCommand, Cart>();
            CreateMap<Cart, CreateCartResult>()
                .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.CartProducts));
            CreateMap<CartProduct, CartProductResultDto>();
        }
    }
}