using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

/// <summary>
/// Concrete implementation of <see cref="ICartRepository"/> using Entity Framework
/// </summary>
public class CartRepository : RepositoryBase<Cart>, ICartRepository
{
    private readonly DefaultContext _context;

    /// <summary>
    /// Initializes a new instance of the <see cref="CartRepository"/> class.
    /// </summary>
    /// <param name="context">The EF Core database context</param>
    public CartRepository(DefaultContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<Cart?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _context.Carts
            .Include(c => c.CartProducts)
            .ThenInclude(p => p.Product)
            .FirstOrDefaultAsync(e => e.Id == id, cancellationToken);

    }

    /// <summary>
    /// Retrieves a cart by the customer's unique identifier, including cart items
    /// </summary>
    /// <param name="userId">The unique identifier of the customer</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The cart if found, or null otherwise</returns>
    public async Task<Cart?> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        return await _context.Carts
            .Include(c => c.CartProducts)
            .FirstOrDefaultAsync(c => c.UserId == userId, cancellationToken);
    }
}