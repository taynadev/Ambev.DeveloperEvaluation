using Ambev.DeveloperEvaluation.Application.Sales.Commands.CreateSale;
using Ambev.DeveloperEvaluation.Application.Sales.Commands.CreateSaleFromCart;
using Ambev.DeveloperEvaluation.Application.Sales.Queries.GetSaleById;
using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;

/// <summary>
/// Profile for mapping between Application and API CreateSale responses
/// </summary>
public class CreateSaleFromCartProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for CreateSale feature
    /// </summary>
    public CreateSaleFromCartProfile()
    {
        CreateMap<CreateSaleFromCartRequest, CreateSaleFromCartCommand>();
        CreateMap<CreateSaleFromCartResult, CreateSaleFromCartResponse>();
        CreateMap<CreateSaleItemFromCartResultDto, CreateSaleItemFromCartResponseDto>();
    }
}
