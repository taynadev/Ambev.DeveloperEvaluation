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
        /// <param name="userId">The unique identifier of the customer</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The cart if found, null otherwise</returns>
        Task<Cart?> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken = default);
    }
}