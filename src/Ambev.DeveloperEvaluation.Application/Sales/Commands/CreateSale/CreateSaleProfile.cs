using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Sales.Commands.CreateSale
{
    /// <summary>
    /// AutoMapper profile for creating sale mappings.
    /// </summary>
    public class CreateSaleProfile : Profile
    {
        public CreateSaleProfile()
        {
            CreateMap<CreateSaleCommand, Sale>()
                .ConstructUsing(cmd => new Sale(
                    cmd.UserId,
                    cmd.CustomerName,
                    cmd.BranchId,
                    cmd.BranchName
                ))
                .ForMember(dest => dest.Items, opt => opt.Ignore());

            CreateMap<CreateSaleItemDto, SaleItem>()
                .ConstructUsing(item => new SaleItem(
                    item.ProductId,
                    item.ProductName,
                    item.Quantity,
                    item.UnitPrice
                ));

            CreateMap<Sale, CreateSaleResult>();

            CreateMap<SaleItem, CreateSaleItemResultDto>();
        }
    }
}
