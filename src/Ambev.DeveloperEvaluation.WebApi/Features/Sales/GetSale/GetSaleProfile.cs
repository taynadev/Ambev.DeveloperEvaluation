using Ambev.DeveloperEvaluation.Application.Sales.Queries.GetSaleById;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSale
{

    /// <summary>
    /// Profile for mapping GetSale feature requests to commands
    /// </summary>
    public class GetSaleProfile : Profile
    {
        /// <summary>
        /// Initializes the mappings for GetSale feature
        /// </summary>
        public GetSaleProfile()
        {
            CreateMap<Guid, GetSaleByIdCommand>()
                .ConstructUsing(id => new GetSaleByIdCommand(id));

            CreateMap<GetSaleByIdResult, GetSaleResponse>();
            CreateMap<SaleItemDto, SaleItemResponseDto>();
        }
    }
}
