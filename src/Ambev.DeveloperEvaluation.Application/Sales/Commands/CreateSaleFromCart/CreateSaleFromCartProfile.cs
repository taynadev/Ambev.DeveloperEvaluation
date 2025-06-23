using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Sales.Commands.CreateSaleFromCart
{
    /// <summary>
    /// Maps the sale entity and command to result.
    /// </summary>
    public class CreateSaleFromCartProfile : Profile
    {
        public CreateSaleFromCartProfile()
        {
            CreateMap<CreateSaleFromCartCommand, Sale>();
            CreateMap<Sale, CreateSaleFromCartResult>();
        }
    }
}
