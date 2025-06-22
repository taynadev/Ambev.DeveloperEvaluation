using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

/// <summary>
/// Implementation of IProductRepository for Product-specific operations using Entity Framework Core
/// Inherits basic CRUD from <see cref="RepositoryBase{Product}"/>
/// </summary>
public class ProductRepository : RepositoryBase<Product>, IProductRepository
{
    /// <summary>
    /// Initializes a new instance of ProductRepository
    /// </summary>
    /// <param name="context">The database context</param>
    public ProductRepository(DefaultContext context) : base(context) { }
}