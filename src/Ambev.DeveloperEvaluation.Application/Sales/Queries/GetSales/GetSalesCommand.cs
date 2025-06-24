using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.Queries.GetSale
{
    /// <summary>
    /// Query to retrieve a sale by its unique identifier.
    /// </summary>
    public class GetSalesCommand : IRequest<GetSalesResult>
    {
        /// <summary>
        /// Query parameters for filtering, ordering, and pagination.
        /// </summary>
        public Dictionary<string, string?> QueryParams { get; }

        public GetSalesCommand(Dictionary<string, string?> queryParams)
        {
            QueryParams = queryParams;
        }
    }
}