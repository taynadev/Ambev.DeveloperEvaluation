using Ambev.DeveloperEvaluation.Application.Sales.Commands.CancelSale;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;

/// <summary>
/// Profile for mapping between Application and API CanceleSale responses
/// </summary>
public class CancelSaleProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for CancelSale feature
    /// </summary>
    public CancelSaleProfile()
    {
        CreateMap<Guid, CancelSaleCommand>()
                        .ConstructUsing(id => new CancelSaleCommand(id));
        CreateMap<CancelSaleResult, CancelSaleResponse>();
    }
}
