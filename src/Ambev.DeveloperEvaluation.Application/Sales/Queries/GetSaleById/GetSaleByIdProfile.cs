using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Sales.Queries.GetSaleById
{
    /// <summary>
    /// AutoMapper profile for mapping <see cref="Sale"/> to <see cref="GetSaleByIdResult"/>.
    /// </summary>
    public class GetSaleByIdProfile : Profile
    {
        public GetSaleByIdProfile()
        {
            CreateMap<SaleItem, SaleItemDto>();
            CreateMap<Sale, GetSaleByIdResult>();
        }
    }
}
