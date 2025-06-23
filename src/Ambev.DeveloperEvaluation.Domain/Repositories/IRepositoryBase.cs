using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Repositories
{
    /// <summary>
    /// Base interface for generic repository operations on domain entities.
    /// Applies to all entities inheriting from BaseEntity.
    /// </summary>
    /// <typeparam name="T">Entity type</typeparam>
    public interface IRepositoryBase<T> where T : BaseEntity
    {
        /// <summary>
        /// Adds a new entity to the repository.
        /// </summary>
        /// <param name="entity">The entity to add.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>The created entity.</returns>
        Task<T> CreateAsync(T entity, CancellationToken cancellationToken = default);

        /// <summary>
        /// Updates an existing entity.
        /// </summary>
        /// <param name="entity">The updated entity.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>The updated entity.</returns>
        Task<T> UpdateAsync(T entity, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves an entity by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>The entity if found, null otherwise.</returns>
        Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a list of an entity.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>The List of an entity if found, an empty collection otherwise.</returns>
        Task<IEnumerable<T>> ListAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Deletes an entity by its unique identifier.
        /// </summary>
        /// <param name="id">The ID of the entity to delete.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>True if the entity was deleted, false otherwise.</returns>
        Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Checks if an entity with the specified ID exists.
        /// </summary>
        /// <param name="id">Entity ID.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>True if the entity exists, false otherwise.</returns>
        Task<bool> ExistsAsync(Guid id, CancellationToken cancellationToken = default);
        Task<(List<T> Items, int TotalCount)> ListWithQueryParamsAsync(Dictionary<string, string?> queryParams);
    }
}
