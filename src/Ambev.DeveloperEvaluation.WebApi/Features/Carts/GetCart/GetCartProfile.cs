﻿using Ambev.DeveloperEvaluation.Application.Carts.Queries.GetCartById;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.GetCart
{

    /// <summary>
    /// Profile for mapping GetCart feature requests to commands
    /// </summary>
    public class GetCartProfile : Profile
    {
        /// <summary>
        /// Initializes the mappings for GetCart feature
        /// </summary>
        public GetCartProfile()
        {
            CreateMap<Guid, GetCartByIdCommand>()
                .ConstructUsing(id => new GetCartByIdCommand(id));
        }
    }
}
