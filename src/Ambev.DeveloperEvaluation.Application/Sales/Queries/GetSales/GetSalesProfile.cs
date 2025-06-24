using Ambev.DeveloperEvaluation.Application.Sales.Queries.GetSale;
using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Sales.Queries.GetSaleById
{
    /// <summary>
    /// AutoMapper profile for mapping Sale and SaleProduct to their result DTOs.
    /// </summary>
    public class GetSalesProfile : Profile
    {
        public GetSalesProfile()
        {
            CreateMap<Sale, SaleDto>();

            CreateMap<SaleItem, SaleItemDto>();
        }
    }
}