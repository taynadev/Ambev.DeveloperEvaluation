using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

/// <summary>
/// Implementation of ISaleRepository for Sale-specific operations using Entity Framework Core
/// Inherits basic CRUD from <see cref="RepositoryBase{User}"/>
/// </summary>
public class SaleRepository : RepositoryBase<Sale>, ISaleRepository
{
    /// <summary>
    /// Initializes a new instance of SaleRepository
    /// </summary>
    /// <param name="context">The database context</param>
    public SaleRepository(DefaultContext context) : base(context) { }
}