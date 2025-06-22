using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

/// <summary>
/// Implementation of ICustomerRepository for Customer-specific operations using Entity Framework Core
/// Inherits basic CRUD from <see cref="RepositoryBase{Customer}"/>
/// </summary>
public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
{
    /// <summary>
    /// Initializes a new instance of CustomerRepository
    /// </summary>
    /// <param name="context">The database context</param>
    public CustomerRepository(DefaultContext context) : base(context) { }
}