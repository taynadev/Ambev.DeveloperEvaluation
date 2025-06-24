using Ambev.DeveloperEvaluation.Common.Validation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Carts.Queries.GetCart
{
    /// <summary>
    /// Query to retrieve a cart by its unique identifier.
    /// </summary>
    public class GetCartsCommand : IRequest<GetCartsResult>
    {
        /// <summary>
        /// Query parameters for filtering, ordering, and pagination.
        /// </summary>
        public Dictionary<string, string?> QueryParams { get; }

        public GetCartsCommand(Dictionary<string, string?> queryParams)
        {
            QueryParams = queryParams;
        }
    }
}