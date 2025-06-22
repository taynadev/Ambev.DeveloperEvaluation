using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories
{

    /// <summary>
    /// Repository interface for Cart entity operations
    /// </summary>
    public interface ICartRepository : IRepositoryBase<Cart>
    {
        /// <summary>
        /// Retrieves a cart by the customer's unique identifier
        /// </summary>
        /// <param name="customerId">The unique identifier of the customer</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The cart if found, null otherwise</returns>
        Task<Cart?> GetByCustomerIdAsync(Guid customerId, CancellationToken cancellationToken = default);
    }
}